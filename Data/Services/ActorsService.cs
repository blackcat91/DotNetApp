using Microsoft.EntityFrameworkCore;
using MVCIntermediate.Data.Base;
using MVCIntermediate.Models;

namespace MVCIntermediate.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        private readonly EntityBaseRepository<Actor> _db;

        public ActorsService(ApplicationDbContext db) : base(db)
        {
            _db = new EntityBaseRepository<Actor>(db);
        }
      

      
    }
}
