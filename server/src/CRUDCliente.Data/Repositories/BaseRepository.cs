using CRUDCliente.Contracts.Queries;
using CRUDCliente.Contracts.Repositories;
using CRUDCliente.Data.Database;
using CRUDCliente.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace CRUDCliente.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IEntity
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        public BaseRepository(ApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;

        public async Task Add(T entity)
        {
            await Db.AddAsync(entity);
            await SaveChanges();
        }
        public async Task Update(T entity)
        {
            Db.Update(entity);
            await SaveChanges();
        }

        public async Task<T> FindById(Guid id, bool useTracking = true)
        {
            return await BeginQuery(useTracking).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<(IEnumerable<T>, int)> FindList<TQuery>(TQuery query, bool useTracking = true) where TQuery : IListResultQuery<T>
        {
            IQueryable<T> queryBuilder = BeginQuery(useTracking);
            IQueryable<T> queryCountBuilder = BeginQuery(useTracking);

            foreach (var inclusao in query.Inclusions)
            {
                queryBuilder = queryBuilder.Include(inclusao);
            }
            foreach (var subInclusao in query.SubInclusions)
            {
                queryBuilder = queryBuilder.Include(subInclusao);
            }

            if (query.Criteria != null)
            {
                queryBuilder = queryBuilder.Where(query.Criteria);
            }

            return (queryBuilder.ToList(), query.Criteria != null ? await queryCountBuilder.CountAsync(query.Criteria) : await queryCountBuilder.CountAsync());
        }

        public async Task<IEnumerable<T>> FindList(bool useTracking = true) => await BeginQuery(useTracking).ToListAsync();

        public async Task<T> Find<TQuery>(TQuery query, bool useTracking = true) where TQuery : ISingleResultQuery<T>
        {
            IQueryable<T> queryBuilder = BeginQuery(useTracking);
            foreach (var inclusao in query.Inclusions)
            {
                queryBuilder = queryBuilder.Include(inclusao);
            }
            foreach (var subInclusao in query.SubInclusions)
            {
                queryBuilder = queryBuilder.Include(subInclusao);
            }
            return await queryBuilder.FirstOrDefaultAsync(query.Criteria);
        }

        public async Task Remove(T entity)
        {
            Db.Remove(entity);
            await SaveChanges();
        }

        private async Task SaveChanges() => await _applicationDbContext.SaveChangesAsync();

        private DbSet<T> Db => _applicationDbContext.Set<T>();

        private IQueryable<T> BeginQuery(bool useTracking) => useTracking ? Db : Db.AsNoTracking();
    }
}