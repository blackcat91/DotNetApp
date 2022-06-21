namespace MVCIntermediate.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task Add(T entity);
        Task<T> Update(int id, T entity);
        Task Remove(int id);

    }
}
