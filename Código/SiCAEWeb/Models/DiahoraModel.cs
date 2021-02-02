using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Asn1.Cms;
using Xamarin.Forms;


namespace SiCAEWeb.Models
{
    public class DiahoraModel
    {
        
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código requerido")]
        public int IdDiahora { get; set; }

        [Display(Name = "HoraInicio")]
        
        [Required(ErrorMessage = "Hora requerida")]
        [DataType(DataType.Time)]
        public TimeSpan HorarioInicio { get; set; }

        [Display(Name = "HoraTermino")]
        [Required(ErrorMessage = "Hora requerida")]
        [DataType(DataType.Time)]
        public TimeSpan HorarioTermino { get; set; }
        
        [Display(Name = "Dia_da_Semana")]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "Nome do dia deve ter entre 3 e 5 caracteres")]
        public string DiaSemana { get; set; }
       

    }

}