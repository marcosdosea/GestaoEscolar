using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class HorarioDTO
    {
        public int IdDiaHora { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioTermino { get; set; }
        public string DiaSemana { get; set; }
    }
}
