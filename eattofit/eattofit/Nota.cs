using System.ComponentModel.DataAnnotations;
namespace eattofit
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nota
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nota()
        {
            this.Pedido1 = new HashSet<Pedido>();
        }
    
        public int IdNota { get; set; }

        [Display(Name = "Data Compra")]
        public Nullable<System.DateTime> DataHoraNota { get; set; }
        [Display(Name = "Cliente")]
        public Nullable<int> IdCliente { get; set; }

        public Nullable<int> IdFornecedor { get; set; }

        [Display(Name = "Número Pedido")]
        public Nullable<int> IdPedido { get; set; }

      
        public Nullable<int> IdEndereco { get; set; }

        [Display(Name = "Forma de Pagameto")]
        public string FormaPagamento { get; set; }

        public Nullable<Decimal> TaxaEntrega { get; set; }


        public string CpfCliente { get; set; }
        public Nullable<int> IdPedidoMobile { get; set; }
        public Nullable<int> IdEnderecoMobile { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Pedido Pedido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido1 { get; set; }
    }
}
