using System.ComponentModel.DataAnnotations;
namespace eattofit
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.Nota = new HashSet<Nota>();
        }
    
        public int IdPedido { get; set; }

        [Display(Name = "Quantidade")]
        public Nullable<int> QantidadePedido { get; set; }

        [Display(Name = "Produto")]
        public Nullable<int> IdProduto { get; set; }

        [Display(Name = "Valor")]
        public Nullable<decimal> ValorPedido { get; set; }

        [Display(Name = "Nota")]
        public Nullable<int> IdNota { get; set; }

        public Nullable<int> IdPedidoMobile { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota> Nota { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Nota Nota1 { get; set; }
    }
}
