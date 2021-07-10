using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SD.BuildingBlocks.Infrastructure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Model;
using WebApi.Interfaces;

namespace WebApi.Services.Services
{
    public class CandidateService : SmServiceBase, ICandidatesService
    {
        private readonly IMapper _mapper;
        public const string AdminName = "User";
        private readonly ICandidateRepository _CandidateRepository;
        private readonly JWTSetting _JWTSettings;
        public CandidateService(IUnitOfWork unitOfWork, ILogger logger,
            ICandidateRepository candidateRepository, IMapper mapper, IOptions<JWTSetting> jwtSettings)
            : base(unitOfWork, logger, "Candidate service")
        {
            _CandidateRepository = candidateRepository;
            _mapper = mapper;
            _JWTSettings = jwtSettings.Value;
        }

        public async Task<Candidate> CreateCandidate(Candidate dto)
        {
            var dataToSave=_mapper.Map<Candidates>((Candidate)dto);
            dataToSave.CreatedBy = AdminName;
            dataToSave.CreatedDate = DateTime.Now;
            dataToSave.ID = Guid.NewGuid().ToString();
            dto.ID = dataToSave.ID;
            _CandidateRepository.Add(dataToSave);
            await _unitofWork.CommitAsync();
            return dto;
        }
        public async Task<Candidate> UpdateCandidate(Candidate data)
        {
            var find = await _CandidateRepository.GetAsync(e => e.ID == data.ID);
            if (find != null)
            {

                find.FullName = data.FullName;
                find.Mobile = data.Mobile;
                find.Age = data.Age;
                find.Email = data.Email;
                find.Username = data.Username;
                find.Password = data.Password;
                find.Address = data.Address;
                find.UpdatedDate = DateTime.Now;
                find.UpdatedBy = AdminName;

                _CandidateRepository.AddOrUpdate(find);
                await _unitofWork.CommitAsync();

                return data;
            }
            else
            {
                return null;
            }

        }
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _CandidateRepository.GetAsync(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null)
            {
                  return new AuthenticateResponse(null, null);
            }
            var token = GenerateJWTToken(_mapper.Map<Candidate>(user));
            return new AuthenticateResponse(_mapper.Map<Candidate>(user), token);
        }

        public async Task<List<Candidate>> GetAll()
        {
                var user = await Task.Run(() => _CandidateRepository.GetAll().ToListAsync());
                return _mapper.Map<List<Candidate>>(user);
        }

        public async Task<Candidate> GetById(string id)
        {
            var find = await _CandidateRepository.GetAsync(e => e.ID == id);
            if (find != null)
            {
                return _mapper.Map<Candidate>(find);
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> DeleteCandidate(string id)
        {
            var find = await _CandidateRepository.GetAsync(e => e.ID == id);
            if (find != null)
            {
                _CandidateRepository.Remove(find);
                await _unitofWork.CommitAsync();
            }
            else
            {
                return false;
            }
            return true;
        }

        private string GenerateJWTToken(Candidate user)
        {
            // generate token that is valid for 5 minutes
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_JWTSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("ID", user.ID.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
