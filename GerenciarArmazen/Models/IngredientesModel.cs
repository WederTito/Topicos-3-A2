namespace GerenciarArmazen.Models
{
    public class IngredientesModel : Ingrediente
    {
        public List<Categoria> ListaCategorias { get; set; }
        public List<Armazenamento> ListaArmazenamentos { get; set; }
    }
}
