using System.ComponentModel.DataAnnotations;
namespace eattofit
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            this.Produto = new HashSet<Produto>();
        }

        
        public int IdCategoria { get; set; }


        [Display(Name = "Descrição Categoria")]
        public string DescriçãoCategoria { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
