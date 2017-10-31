using System.ComponentModel.DataAnnotations;
namespace eattofit
{
    using System;
    using System.Collections.Generic;
    
    public partial class Endereco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Endereco()
        {
            this.Fornecedor = new HashSet<Fornecedor>();
            this.Nota = new HashSet<Nota>();
        }
        [Key]
        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar Rua")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o N�mero")]
        [Display(Name = "N�mero")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o CEP")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar a Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o Estado")]
        public string Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fornecedor> Fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
