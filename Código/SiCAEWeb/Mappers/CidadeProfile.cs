using Core;
using SiCAEWeb.Models;
using AutoMapper;
using System;

namespace SiCAEWeb.Mappers
{
    public class CidadeProfile : Profile
    {
        public CidadeProfile()
        {
            CreateMap<CidadeModel, Cidade>().ReverseMap();
        }
    }
}
