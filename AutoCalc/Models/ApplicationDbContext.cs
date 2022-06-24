
using Microsoft.EntityFrameworkCore;

namespace AutoCalc.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Veiculo>? Veiculos { get; set; }
        public DbSet<Abastecimento>? Abastecimentos { get; set; }
    }
}
