using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GerenciarArmazen.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Column("Nome")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Column("Medida")]
        [Display(Name = "Medida")]
        public string? Medida { get; set; }

        public virtual Ingrediente? Ingrediente { get; set; }

    }
}
