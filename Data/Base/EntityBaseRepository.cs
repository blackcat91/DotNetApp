using Microsoft.EntityFrameworkCore;

namespace MVCIntermediate.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T: class , IEntityBase,  new()
    {
        private readonly ApplicationDbContext _db;

        public EntityBaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Add(T entity)
        {
            
                await _db.Set<T>().AddAsync(entity);
                await _db.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> entity = await _db.Set<T>().ToListAsync();
            return entity;
        }

        public async Task<T> GetById(int id)
        {
            if (id != 0 || id != null)
            {
                T entity = await _db.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
                return entity;
            }
            return null;
        }

        public async Task Remove(int id)
        {
            T exist = await _db.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            if (exist != null)
            {
                _db.Set<T>().Remove(exist);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            T exist = await _db.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            if (exist != null && entity != null)
            {
                exist = entity;
                await _db.SaveChangesAsync();
            }
            return entity;
        }
    }
}
