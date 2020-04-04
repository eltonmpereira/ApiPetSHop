using Microsoft.EntityFrameworkCore;
using WebApplication1.Entidades;
using WebApplication1.Entidades.Pets;

namespace WebApplication1
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        {
        }
        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebApiContext).Assembly);
        }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Pet> Pet { get; set; }
    }
}
