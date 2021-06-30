using AutoMapper;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SiCAEWeb.Models
{
    public class AlunoModel
    {
        [Display(Name = "Código")]
        [Key]
        [HiddenInput]
        public int IdAluno { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome requerido")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Nome do aluno deve ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Nome_Social")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome do aluno deve ter entre 3 e 50 caracteres")]
        public string NomeSocial { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.DateTime, ErrorMessage = "Data válida requerida!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Data de nascimento não preenchida!")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Conferir dígitos do CPF")]
        [Required(ErrorMessage = "CPF requerido")]
        public string Cpf { get; set; }

        [Display(Name = "Rua")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Conferir nome da rua")]
        [Required(ErrorMessage = "Nome da rua requerido")]
        public string Rua { get; set; }

        [Display(Name = "CEP")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "Conferir dígitos do CEP")]
        [Required(ErrorMessage = "CEP requerido")]
        public string Cep { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Conferir endereço de email")]
        [Required(ErrorMessage = "Email requerido")]
        public string Email { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Nome do aluno deve ter entre 5 e 50 caracteres")]
        [Required(ErrorMessage = "Nome da cidade requerido")]
        public string Cidade { get; set; }

        [Display(Name = "Procedencia Escolar")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Conferir a procedencia escolar")]
        [Required(ErrorMessage = "Procedencia escolar requerida")]
        public string ProcedenciaEscolar { get; set; }

        [Display(Name = "Nacionalidade")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Conferir a nacionalidade")]
        [Required(ErrorMessage = "Nacionalidade requerida")]
        
        public string Nacionalidade { get; set; }

        [Display(Name = "Identidade")]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "Conferir a Identidade")]
        [Required(ErrorMessage = "Número da identidade requerido")]
        public string Identidade { get; set; }
        [Display(Name = "Telefone")]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "Conferir numero de telefone")]
        [Required(ErrorMessage = "Telefone requerido")]
        public string Telefone { get; set; }
        [Display(Name = "Sexo")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Inserir o sexo")]
        [Required(ErrorMessage = "Sexo requerido")]
        public string Sexo { get; set; }
        [Display(Name = "Certidao de Nascimento")]
        [StringLength(32, MinimumLength = 31, ErrorMessage = "Conferir a certidao")]
        [Required(ErrorMessage = "Certidão requerida")]
        public string CertidaoNascimento { get; set; }
        [Display(Name = "Cor/Raça")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Campo nao preenchido")]
        [Required(ErrorMessage = "Cor/Raça requerido(a)")]
        public string CorRaca { get; set; }
        [Display(Name = "Sus")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Conferir digitos do sus")]
        [Required(ErrorMessage = "Numero do Sus requerido")]
        public string Sus { get; set; }
        [Display(Name = "Número do NIS")]
        [StringLength(11, MinimumLength = 5, ErrorMessage = "Conferir digitos do NIS")]
        public string Nis { get; set; }
        [Display(Name = "Bairro")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Campo não preenchido corretamente")]
        [Required(ErrorMessage = "Bairro requerido")]
        public string Bairro { get; set; }
        [Display(Name = "Complemento")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Conferir complemento")]
        public string Complemento { get; set; }
        [Display(Name = "Número da casa ou Imóvel")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Conferir o número do imóvel")]
        [Required(ErrorMessage = "Número do imóvel/casa requerido")]
        public string NumeroImovel { get; set; }
        




    }
}
