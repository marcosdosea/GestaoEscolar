using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SiCAEWeb.Models
{
    public class DiahoraModel
    {

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código requerido")]
        public int IdDiahora { get; set; }

        [Display(Name = "HoraInicio")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Hora requerida")]
        public int HoraInicio { get; set; }

        [Display(Name = "HoraTermino")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Hora requerida")]
        public int HoraTermino { get; set; }
        
        [Display(Name = "Dia_da_Semana")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome do dia deve ter entre 5 e 45 caracteres")]
        public string DiaSemana { get; set; }
    }

}
