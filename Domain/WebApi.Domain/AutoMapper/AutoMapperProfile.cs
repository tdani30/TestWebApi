using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Domain.Entities;
using WebApi.Domain.Model;

namespace WebApi.Domain.AutoMapper
{
   public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Candidates, Candidate>();
            CreateMap<Candidate,Candidates>();
        }
    }
}
