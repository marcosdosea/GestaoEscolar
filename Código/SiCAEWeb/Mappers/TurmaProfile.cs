using AutoMapper;
using Models;
using Core;

namespace Mappers
{
	public class TurmaProfile : Profile
	{
		public TurmaProfile()
		{
			CreateMap<TurmaModel, Turma>().ReverseMap();
		}
	}
}
