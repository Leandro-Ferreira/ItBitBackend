using ITBIT.CORE.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ITBIT.InfraEstrutura.Data
{
    public class UsuarioDBContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Sexo> Sexo { get; set; }

        public UsuarioDBContext(DbContextOptions<UsuarioDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sexo>().HasData(
                new Sexo(1,"Masculino"),  
                new Sexo(2,"Feminino")   
            );
        }

    } 
}
