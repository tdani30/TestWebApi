using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using WebApi.Domain.Model;
using WebApi.Interfaces;

namespace WebApps.Controllers
{
    [ApiController]
    public class UserController : SmControllerBase
    {
        ICandidatesService _candidatesService;
        public UserController(ILogger logger, ICandidatesService candidatesService) : base(logger, nameof(UserController))
        {
            _candidatesService = candidatesService;
        }

        [HttpGet]
        [Route("api/User/GetAllCandidate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAllCandidate()
        {
            try
            {
                var result = await _candidatesService.GetAll();
                return Ok(ServiceResponse.SuccessResponse(result));
            }
            catch (ArgumentException ex)
            {
                return HandleUserException(ex);
            }
            catch (Exception ex)
            {
                return HandleOtherException(ex);
            }
        }

        [HttpGet]
        [Route("api/User/GetCandidate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetCandidate(string id)
        {
            try
            {
                var result = await _candidatesService.GetById(id);
                return Ok(ServiceResponse.SuccessResponse(result));
            }
            catch (ArgumentException ex)
            {
                return HandleUserException(ex);
            }
            catch (Exception ex)
            {
                return HandleOtherException(ex);
            }
        }

        [HttpGet]
        [Route("api/User/DeleteCandidate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> DeleteCandidate(string id)
        {
            try
            {
                var result = await _candidatesService.DeleteCandidate(id);
                return Ok(ServiceResponse.SuccessResponse(result));
            }
            catch (ArgumentException ex)
            {
                return HandleUserException(ex);
            }
            catch (Exception ex)
            {
                return HandleOtherException(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/User/Authenticate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            try
            {
                var response = await _candidatesService.Authenticate(model);

                if (response == null)
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }
                var dsdsd = ServiceResponse.SuccessResponse(response);
                return Ok(ServiceResponse.SuccessResponse(response));
            }
            catch (ArgumentException ex)
            {
                return HandleUserException(ex);
            }
            catch (Exception ex)
            {
                return HandleOtherException(ex);
            }
        }

        [HttpPost]
        [Route("api/User/UpdateCandidate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UpdateCandidate(Candidate model)
        {
            try
            {
                var response = await _candidatesService.UpdateCandidate(model);

                if (response == null)
                    return BadRequest(new { message = "Error while updating the record!" });

                return Ok(ServiceResponse.SuccessResponse(response));
            }
            catch (ArgumentException ex)
            {
                return HandleUserException(ex);
            }
            catch (Exception ex)
            {
                return HandleOtherException(ex);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("api/User/CreateCandidate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateCandidate(Candidate model)
        {
            try
            {
                var response = await _candidatesService.CreateCandidate(model);

                if (response == null)
                    return BadRequest(new { message = "Error while updating the record!" });

                return Ok(ServiceResponse.SuccessResponse(response));
            }
            catch (ArgumentException ex)
            {
                return HandleUserException(ex);
            }
            catch (Exception ex)
            {
                return HandleOtherException(ex);
            }
        }


    }
}
