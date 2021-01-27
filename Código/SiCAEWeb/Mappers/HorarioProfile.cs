using AutoMapper;
using Core;
using SiCAEWeb.Models;

namespace SiCAEWeb.Mappers
{
    public class HorarioProfile : Profile
    {
        public HorarioProfile()
        {
            CreateMap<DiahoraModel, Diahora>().ReverseMap();
        }
    }
}
