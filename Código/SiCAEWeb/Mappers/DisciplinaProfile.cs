using Core;
using SiCAEWeb.Models;
using AutoMapper;
using System;

namespace SiCAEWeb.Mappers
{
    public class DisciplinaProfile : Profile
    {
        public DisciplinaProfile()
        {
            CreateMap<DisciplinaModel, Disciplina>().ReverseMap();
        }
    }
}
