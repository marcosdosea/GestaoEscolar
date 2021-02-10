using System.ComponentModel.DataAnnotations;


namespace SiCAEWeb.Models
{
	public class DisciplinaModel
	{

		[Display(Name = "Código")]
		[Required(ErrorMessage = "Código requerido")]
		public int IdDisciplina { get; set; }

		[Required(ErrorMessage = "Nome requerido")]
		[StringLength(45, MinimumLength = 5, ErrorMessage = "Nome da disciplina é muito grande")]
		public string Nome { get; set; }
	}
}
