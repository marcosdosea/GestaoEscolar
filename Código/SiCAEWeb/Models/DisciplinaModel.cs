using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Asn1.Cms;
using Xamarin.Forms;


namespace SiCAEWeb.Models
{
    public class DisciplinaModel
    {

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código requerido")]
        public int IdDisciplina { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [StringLength(45,MinimumLength = 5, ErrorMessage = "Nome da disciplina é muito grande")]
        public string Nome { get; set; }



    }

}
