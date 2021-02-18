using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SiCAEWeb.Models
{
    public class NotificacaoModel
    {
        public string idNotificacao { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Limite de 50 caracteres ultrapassado.")]
        public string titulo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "Limite de 150 caracteres ultrapassado.")]
        public string descricao { get; set; }

        [Display(Name = "Prioridade")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Text)]
        [StringLength(45, ErrorMessage = "Limite de 45 caracteres ultrapassado.")]
        public string prioridade { get; set; }

        [Display(Name = "Remetente")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Text)]
        [StringLength(45, ErrorMessage = "Limite de 45 caracteres ultrapassado.")]
        public string remetente { get; set; }

        [Display(Name = "Destinatário(s)")]
        public bool notificaProfessor { get; set; }

        public bool notificaResponsavel { get; set; }







    }
}
