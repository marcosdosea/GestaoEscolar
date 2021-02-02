using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Asn1.Cms;
using Xamarin.Forms;
namespace SiCAEWeb.Models
{
    public class AlunoModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código requerido")]
        public int IdAluno { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome requerido")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Nome do aluno deve ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Nome_Social")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome do aluno deve ter entre 3 e 50 caracteres")]
        public string NomeSocial { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DataNascimento { get; set; }

        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Conferir dígitos do CPF")]
        public string Cpf { get; set; }

        [Display(Name = "Rua")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Conferir nome da rua")]
        public string Rua { get; set; }

        [Display(Name = "CEP")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Conferir dígitos do CEP")]
        public string Cep { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Conferir endereço de email")]
        public string Email { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Nome do aluno deve ter entre 5 e 50 caracteres")]
        public string Cidade { get; set; }

        [Display(Name = "Procedencia Escolar")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Conferir a procedencia escolar")]
        public string ProcedenciaEscolar { get; set; }

        [Display(Name = "Nacionalidade")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Conferir a nacionalidade")]
        public string Nacionalidade { get; set; }

        [Display(Name = "Identidade")]
        [StringLength(8, MinimumLength = 5, ErrorMessage = "Conferir a Identidade")]
        public string Identidade { get; set; }
        [Display(Name = "Telefone")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Conferir numero de telefone")]
        public string Telefone { get; set; }
        [Display(Name = "Sexo")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Inserir o sexo")]
        public string Sexo { get; set; }
        [Display(Name = "Certidao de Nascimento")]
        [StringLength(32, MinimumLength = 5, ErrorMessage = "Conferir a certidao")]
        public string CertidaoNascimento { get; set; }
        [Display(Name = "Cor/Raça")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Campo nao preenchido")]
        public string CorRaca { get; set; }
        [Display(Name = "Sus")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Conferir digitos do sus")]
        public string Sus { get; set; }
        [Display(Name = "Número do NIS")]
        [StringLength(11, MinimumLength = 5, ErrorMessage = "Conferir digitos do NIS")]
        public string Nis { get; set; }
        [Display(Name = "Bairro")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo não preenchido corretamente")]
        public string Bairro { get; set; }
        [Display(Name = "Complemento")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Conferir complemento")]
        public string Complemento { get; set; }
        [Display(Name = "Número da casa ou Imóvel")]
        [StringLength(5, MinimumLength = 4, ErrorMessage = "Conferir o número do imóvel")]
        public string NumeroImovel { get; set; }
        
        
        



    }
}
