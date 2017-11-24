using System.ComponentModel.DataAnnotations;
namespace eattofit
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cartao
    {
        public int IdCartao { get; set; }

        public string Bandeira { get; set; }

        [Display(Name = "Imaagem")]
        public string ImagemUrl { get; set; }
        public Nullable<int> IdFornecedor { get; set; }
    
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
