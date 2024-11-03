using Challenge_Innov8Tech.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Innov8Tech.Infrastructure
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<RamoEntity> Ramos { get; set; }

      
    }
}
