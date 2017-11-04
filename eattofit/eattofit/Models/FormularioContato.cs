using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eattofit.Models
{
    public class FormularioContato
    {
        [Key]
        public int IdFormulario { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Nome")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Obrigatório informar Assunto")]
        public string Assunto { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Informe um email válido.")]
        [Display(Name = "E-mail")]
        public string Remetente { get; set; }


        [Required(ErrorMessage = "Obrigatório incluir uma mensagem")]
        public string Mensagem { get; set; }
    }
}