using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
         where TEntity : BaseEntity
    {
        private readonly DatabaseContext dbContext;

        public GenericRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            dbContext.Set<TEntity>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
