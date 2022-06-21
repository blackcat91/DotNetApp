using MVCIntermediate.Data.Base;
using MVCIntermediate.Models;

namespace MVCIntermediate.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        private readonly EntityBaseRepository<Producer> _db;

        public ProducersService(ApplicationDbContext db) : base(db)
        {
            _db = new EntityBaseRepository<Producer>(db);
        }

    }
}
