using AutoMapper;
using Core;
using SiCAEWeb.Models;

namespace SiCAEWeb.Mappers
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<AlunoModel, Aluno>().ReverseMap();
        }
    }
}
