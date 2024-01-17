using Crud_Cliente.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Crud_Cliente.BancoDeDados {
    public class Contexto : DbContext {

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
    }
}
