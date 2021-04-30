using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiCAEWeb.Models
{
    public class CidadeModel
    {
        [Display(Name = "")]
        [Key]
        [HiddenInput]
        public int idCidade { get; set; }

        [Display(Name = "CódigoIBGE")] //Verificar validação de campo unique
        [Required(ErrorMessage = "Código IBGE requerido")]
        [Range(1000000,9999999, ErrorMessage = "Código IBGE tem 7 dígitos")] 
        public int CodIbge { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Nome da cidade requerido")] // será substituido futuramente pela api do IBGE
        public string Nome { get; set; }

        
        [Required(ErrorMessage = "Nome do Estado requerido")] // será substituido futuramente pela api do IBGE
        public string Estado { get; set; }
    }
}
