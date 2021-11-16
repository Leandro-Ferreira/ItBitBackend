using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ITBIT.InfraEstrutura.Data
{
    public class UsuarioDBContextFactory : IDesignTimeDbContextFactory<UsuarioDBContext>
    {
        public UsuarioDBContext CreateDbContext(string[] args)
        {
            string caminho = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            var configuration = new ConfigurationBuilder()
                   .SetBasePath(caminho + "\\ITBIT\\ITBIT.API")
                   .AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<UsuarioDBContext>();

            var connectionString = configuration
                        .GetConnectionString("ITBITConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new UsuarioDBContext(optionsBuilder.Options);
        }
    }
}
