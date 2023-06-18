using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GerenciarArmazen.Models
{
    [Table("Armazenamento")]
    public class Armazenamento
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        public virtual Ingrediente? Ingrediente { get; set; }

    }
}
