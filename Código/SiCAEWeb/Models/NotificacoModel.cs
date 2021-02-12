using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SiCAEWeb.Models
{
    public class NotificacaoModel
    {
        [Key]
        [Display(Name = "Codigo")]
        public int idNotificacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Limite de 50 caracteres ultrapassado.")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "Limite de 150 caracteres ultrapassado.")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Text)]
        [StringLength(45, ErrorMessage = "Limite de 45 caracteres ultrapassado.")]
        public string prioridade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Text)]
        [StringLength(45, ErrorMessage = "Limite de 45 caracteres ultrapassado.")]
        public string remetente { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Text)]
        [StringLength(45, ErrorMessage = "Limite de 45 caracteres ultrapassado.")]
        public string destinatario { get; set; }




    }
}
