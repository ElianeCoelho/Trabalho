using System.ComponentModel.DataAnnotations;
namespace eattofit
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nota
    {
        public int IdNota { get; set; }
        public Nullable<System.DateTime> DataHoraNota { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdFornecedor { get; set; }
        public Nullable<int> IdPedido { get; set; }
        public Nullable<int> IdEndereco { get; set; }
        public string FormaPagamento { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
