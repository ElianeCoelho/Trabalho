using System.ComponentModel.DataAnnotations;

namespace eattofit
{
    using System;
    using System.Collections.Generic;
    
    public partial class Produto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produto()
        {
            this.Pedido = new HashSet<Pedido>();
        }
    
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Nome")]
        [Display(Name = "Nome Produto")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
 "Números e caracteres especiais não são permitidos no Nome.")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Descrição")]
        [Display(Name = "Descrição")]
         public string DescricaoProduto { get; set; }

       
        [Display(Name = "Valor Produto")]
        public Nullable<decimal> ValorProduto { get; set; }


        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Obrigatório informar Categoria")]
        public Nullable<int> IdCategoria { get; set; }


        public Nullable<int> IdFornecedor { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
