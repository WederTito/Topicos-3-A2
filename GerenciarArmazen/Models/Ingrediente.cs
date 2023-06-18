namespace GerenciarArmazen.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime Validade { get; set; }
        public int CategoriaId { get; set; }
        public int ArmazenamentoId { get; set; }

        public virtual Categoria? Categoria { get; set; }
        public virtual Armazenamento? Armazenamento { get; set; }
    }
}
