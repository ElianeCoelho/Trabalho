using System.ComponentModel.DataAnnotations;
namespace eattofit
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fornecedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fornecedor()
        {
            this.Cartao = new HashSet<Cartao>();
            this.Nota = new HashSet<Nota>();
            this.Produto = new HashSet<Produto>();
        }
    
        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Nome")]
        [Display(Name = "Nome do Representante")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Nome Empresa")]
        [Display(Name = "Nome da Empresa no App")]
        public string RazaoSocial { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Informe um email válido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Deve conter no mínimo 6 caracteres", MinimumLength = 6)]
        [Required(ErrorMessage = "Obrigatório informar a Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


        [Display(Name = "Confirme Senha")]
        [Compare("Senha", ErrorMessage = "Senha não confere")]
        [DataType(DataType.Password)]
        public string ConfirmaSenha { get; set; }


        public Nullable<int> IdEndereco { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cartao> Cartao { get; set; }
        public virtual Endereco Endereco { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota> Nota { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
