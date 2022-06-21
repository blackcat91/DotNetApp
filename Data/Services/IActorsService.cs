using MVCIntermediate.Data.Base;
using MVCIntermediate.Models;

namespace MVCIntermediate.Data.Services
{
    public interface IActorsService : IEntityBaseRepository<Actor>
    {
        Task<IEnumerable<Actor>> GetAll();

        Task<Actor> GetById(int id);

        Task Add(Actor actor);
        Task<Actor> Update(int id, Actor actor);
        Task Remove(int id);

    }
}
