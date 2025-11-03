using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BuildTrackMVC.Models;

namespace BuildTrackMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }
        public DbSet<RegistoMaoObra> RegistosMaoObra { get; set; }
        public DbSet<RegistoPagamento> RegistosPagamentos { get; set; }
    }
}