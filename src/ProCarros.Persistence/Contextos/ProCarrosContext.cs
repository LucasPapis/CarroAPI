using Microsoft.EntityFrameworkCore;
using ProCarros.Domain;

namespace ProCarros.Persistence.Contextos
{
    public class ProCarrosContext : DbContext
    {
        public ProCarrosContext(DbContextOptions<ProCarrosContext> options) : base(options) {}
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Carro> Carros { get; set; }
    }
}