using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using SiCAEWeb.Models;

namespace SiCAEWeb.Mappers
{
    public class NotificacaoProfile : Profile 
    {
        public NotificacaoProfile()
        {
            CreateMap<NotificacaoModel, Notificacao>().ReverseMap();
        }
    }
}
