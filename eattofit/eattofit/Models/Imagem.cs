using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eattofit.Models
{
    public class Imagem
    {
        [Key]
        public int IdImagem { get; set; }

        public string CaminhoImg { get; set; }
    }
}