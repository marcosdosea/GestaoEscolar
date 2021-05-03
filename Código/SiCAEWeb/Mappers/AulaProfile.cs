using AutoMapper;
using Core;
using SiCAEWeb.Models;
using System;

namespace SiCAEWeb.Mappers
{
    public class AulaProfile : Profile
    {
        public AulaProfile()
        {
            CreateMap<AulaModel, Aula>().ReverseMap();
        }
    }
}
