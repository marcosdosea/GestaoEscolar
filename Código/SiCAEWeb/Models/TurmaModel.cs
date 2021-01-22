using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TurmaModel
    {
		[Display(Name ="Código")]
		[Required(ErrorMessage = "Código do autor é obrigatório")]
		public int IdTurma { get; set; }
		
		[Required(ErrorMessage ="Campo requerido")]
		[StringLength(45, MinimumLength =5, ErrorMessage = "Nome do autordeve ter entre 5 e 45 caracteres")]
		public string NomeTurma { get; set; }
		
		[Display(Name = "Ano Nascimento")]
		[DataType(DataType.Date, ErrorMessage ="Data válida requerida")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime AnoNascimento { get; set; }
    }
}
