using System.Linq.Expressions;

namespace BuildingBlocks.RepositorySpecification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Criteria { get; }
        Expression<Func<T, object>>? OrderBy { get; }
        Expression<Func<T, object>>? OrderByDesc { get; }
        bool IsDistinct { get; }
        int Skip { get; }
        int Take { get; }
        bool IsPaginationEnabled { get; }
    }

    public interface ISpecification<T, TResult> : ISpecification<T>
    {
        Expression<Func<T, TResult>>? Select { get; }
    }
}