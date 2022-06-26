using cliente.aplicacion.Interfaces;
using cliente.dominio.Entities;
using cliente.dominio.Entities.bp_cliente;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace cliente.persistencia.Context
{
    public class ApplicationDBContext : DbContext
    {
        private readonly IMontoMaximo timeServices;

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options,
            IMontoMaximo timeServices)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.timeServices = timeServices;
        }

        public DbSet<Cliente> Clientes { get; set; }

        /// <summary>
        /// Metodo para ejecutar las peticiones sobre la base de datos
        /// </summary>
        /// <param name="cancellationToken">token de cancelacion</param>
        /// <returns>codigo del CRUD</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var item in ChangeTracker.Entries<AuditBaseClass>())
            {
                switch (item.State)
                {
                    case EntityState.Deleted:
                        //item.Entity.ModificadoEn = timeServices.AhoraUtc;
                        item.Entity.Estado = "I";
                        item.State = EntityState.Modified;
                        break;
                    case EntityState.Modified:
                        //item.Entity.ModificadoEn = timeServices.AhoraUtc;
                        break;
                    case EntityState.Added:
                        //item.Entity.CreadoEn = timeServices.AhoraUtc;
                        item.Entity.Estado = "A";
                        break;
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
