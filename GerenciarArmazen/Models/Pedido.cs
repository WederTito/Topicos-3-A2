using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GerenciarArmazen.Models
{
    public enum Mesa
    {
        Mesa1, Mesa2, Mesa3, Mesa4, Mesa5,
        Mesa6, Mesa7, Mesa8, Mesa9, Mesa10
    }
    public class Pedido
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descricao")]
        public string? Descricao { get; set; }
        
        [Column("Mesa")]
        [Display(Name = "Mesa")]
        public Mesa? mesa { get; set; }

        public int PratoId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Prato? Prato { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
