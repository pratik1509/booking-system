namespace BuildingBlocks.RepositorySpecification
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetListAsync();
        Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetEntityListWithSpecAsync(ISpecification<T> spec);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        bool Exist(int id);
        Task<bool> SaveAllAsync();
    }
}