using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiCAEWeb.Models
{
    public class PessoaModel
    {
        [Key]
        [Display(Name = "Código Pessoa ")]
        public int IdPessoa { get; set; }

        [Display(Name = "Nome Social ")]
        [StringLength(50, ErrorMessage = "Limite de 50 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        public string NomeSocial { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(11, ErrorMessage = "Limite de 11 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###.###.###-##}")]
        public string Cpf { get; set; }

        [Display(Name = "Rua")]
        [StringLength(50, ErrorMessage = "Limite de 50 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Rua { get; set; }

        [Display(Name = "CEP")]
        [DataType(DataType.Text)]
        [StringLength(8, ErrorMessage = "Limite de 8 caracteres ultrapassado.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#####-###}")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Cep { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "Limite de 30 caracteres ultrapassado.")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(160, ErrorMessage = "Limite de 160 caracteres ultrapassado.")]
        public string Cidade { get; set; }

        [Display(Name = "Profissão")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(45, ErrorMessage = "Limite de 45 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        public string Profissao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(20, ErrorMessage = "Limite de 20 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        public string Nacionalidade { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(12, ErrorMessage = "Limite de 12 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        public string Identidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(11, ErrorMessage = "Limite de 11 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(##) 9 ####-####}")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(1, ErrorMessage = "Limite de 1 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        public string Sexo { get; set; }

        [Display(Name = "Cor/Raça")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(45, ErrorMessage = "Limite de 45 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        public string CorRaca { get; set; }


        [StringLength(50, ErrorMessage = "Limite de 50 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        public string Complemento { get; set; }
      
        [Display(Name = "Número")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(5, ErrorMessage = "Limite de 5 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        public string NumeroImovel { get; set; }

        [StringLength(50, ErrorMessage = "Limite de 50 caracteres ultrapassado.")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Bairro { get; set; }

        public string TipoPessoa { get; set; } = "Diretor";
    }
}
