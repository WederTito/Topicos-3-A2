using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciarArmazen.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Column("Matricula")]
        [Display(Name = "Matricula")]
        public string? Matricula { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha")]
        public string? Senha { get; set; }

        [Column("Gerente")]
        [Display(Name = "Gerente")]
        public Boolean Gerente { get; set; }


        public virtual Pedido? Pedido { get; set; }
    }
}
