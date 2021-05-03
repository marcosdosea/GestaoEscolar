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
    public class AulaModel
    {
        [Display(Name = "Codigo")]
        [Key]
        [HiddenInput]
        public int IdAula { get; set; }

        [Display(Name = "Conteudo")]
        [Required(ErrorMessage = "Nome requerido")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Nome do conteudo deve ter entre 3 e 50 caracteres")]
        public string Conteudo { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
    }
}
