namespace BuildingBlocks.RepositorySpecification
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> query,
        ISpecification<T> specification)
        {
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDesc != null)
            {
                query = query.OrderByDescending(specification.OrderByDesc);
            }

            if (specification.IsDistinct)
            {
                query = query.Distinct();
            }

            if (specification.IsPaginationEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            return query;
        }

        public static IQueryable<TResult> GetQuery<TSpec, TResult>(IQueryable<T> query,
        ISpecification<T, TResult> specification)
        {
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDesc != null)
            {
                query = query.OrderByDescending(specification.OrderByDesc);
            }

            var selectQuery = query as IQueryable<TResult>;

            if (specification.Select != null)
            {
                selectQuery = query.Select(specification.Select);
            }

            if (specification.IsDistinct)
            {
                selectQuery = selectQuery?.Distinct();
            }

            if (specification.IsPaginationEnabled)
            {
                selectQuery = selectQuery?.Skip(specification.Skip).Take(specification.Take);
            }

            return selectQuery ?? query.Cast<TResult>();
        }
    }
}