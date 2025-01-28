using System.Dynamic;
using System.Linq.Expressions;

namespace BuildingBlocks.RepositorySpecification
{
    public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
    {
        protected BaseSpecification() : this(null) { }
        public Expression<Func<T, bool>>? Criteria => criteria;

        public Expression<Func<T, object>>? OrderBy { get; private set; }

        public Expression<Func<T, object>>? OrderByDesc { get; private set; }

        public bool IsDistinct { get; private set; }

        public int Skip { get; private set; }

        public int Take { get; private set; }
        public bool IsPaginationEnabled { get; private set; }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }

        protected void ApplyDistinct()
        {
            IsDistinct = true;
        }
    }

    public class BaseSpecification<T, TResult>(Expression<Func<T, bool>>? criteria)
    : BaseSpecification<T>(criteria), ISpecification<T, TResult>
    {
        public Expression<Func<T, TResult>>? Select { get; private set; }

        protected void AddSelect(Expression<Func<T, TResult>>? selectExpression)
        {
            Select = selectExpression;
        }

    }
}