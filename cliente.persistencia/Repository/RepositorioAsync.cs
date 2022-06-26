using Ardalis.Specification.EntityFrameworkCore;
using cliente.aplicacion.Interfaces;
using cliente.persistencia.Context;

namespace cliente.persistencia.Repository
{
    public class RepositorioAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDBContext dbContext;

        public RepositorioAsync(ApplicationDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
