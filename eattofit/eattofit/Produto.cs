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
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public Nullable<decimal> ValorProduto { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public Nullable<int> IdFornecedor { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
