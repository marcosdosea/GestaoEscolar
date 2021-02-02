using AutoMapper;
using Core;
using SiCAEWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiCAEWeb.Mappers
{
    public class EscolaProfile : Profile
    {
        public EscolaProfile()
        {
            CreateMap<EscolaModel, Escola>().ReverseMap();
        }
    }
}
