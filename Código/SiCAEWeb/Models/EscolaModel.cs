using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiCAEWeb.Models
{
    public class EscolaModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código requerido")]
        public int IdEscola { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Telefone requerido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Nome da rua requerido")]
        public string Rua { get; set; }


        [Display(Name = "Número")]
        [Required(ErrorMessage = "Número requerido")]
        public string NumeroImovel { get; set; }

        [Required(ErrorMessage = "Bairro requerido")]
        public string Bairro { get; set; }

        public string Complemento { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "CEP requerido")]
        public string Cep { get; set; }

        [Display(Name = "Código IBGE")]
        [Required(ErrorMessage = "Código IBGE requerido")]
        public int CodIbge { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "CNPJ requerido")]
        [StringLength(18, MinimumLength = 14, ErrorMessage = "O CNPJ tem no mínimo 14 caracteres (sem pontos, barras e tracos)")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "E-mail requerido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Código do Diretor")]
        [Required(ErrorMessage = "Código do diretor requerido")]
        public string IdDiretor { get; set; }






    }
}
