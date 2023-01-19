using CQRSImplementation.Application.Interfaces.IRepository;
using CQRSImplementation.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CQRSImplementation.Persistence.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        public GenericRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public async Task<bool> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }


        public async Task<bool> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Detached;

            context.Set<T>().Update(entity);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
