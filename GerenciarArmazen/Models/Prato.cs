namespace GerenciarArmazen.Models
{
    public class Prato
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int IngredienteId { get; set; }

        public virtual Ingrediente? Ingrediente { get; set; }
        public virtual Pedido? Pedido { get; set; }
    }
}
