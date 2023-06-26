using ApiCliente.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiCliente.DbContexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Flota> flota { get; set; }
        public DbSet<Marca> marca { get; set; }
    }
}
