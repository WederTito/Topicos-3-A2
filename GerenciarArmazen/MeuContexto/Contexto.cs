using GerenciarArmazen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GerenciarArmazen.MeuContexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { 

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Armazenamento> Armazenamento { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set;}
        public DbSet<Prato> Prato { get; set; }

    }
}
