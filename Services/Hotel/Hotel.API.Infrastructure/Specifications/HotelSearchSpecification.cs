using BuildingBlocks.RepositorySpecification.Specification;

namespace Hotel.API.Infrastructure.Specifications
{
    public class HotelSearchSpecification : Specification<Entities.Hotel>
    {
        public HotelSearchSpecification(HotelSpecificationParams parameters)
            : base(hotel =>
                (string.IsNullOrEmpty(parameters.Name) || hotel.City.Contains(parameters.Name))
                && (string.IsNullOrEmpty(parameters.Address) || hotel.City.Contains(parameters.Address))
                && (string.IsNullOrEmpty(parameters.Country) || hotel.City.Contains(parameters.Country))
                && (string.IsNullOrEmpty(parameters.City) || hotel.City.Contains(parameters.City))
                && (parameters.StarRating.HasValue || hotel.StarRating >= parameters.StarRating))
        {
            AddSorting(parameters);
            AddPaging(parameters);
        }

        #region private members

        private void AddSorting(HotelSpecificationParams parameters)
        {
            if (string.IsNullOrEmpty(parameters.SortBy) || !SortByFields.ContainsKey(parameters.SortBy))
            {
                // Default sorting by Name if no valid SortBy is specified
                parameters.SortBy = "Name";
            }

            var sortField = SortByFields[parameters.SortBy];

            if (parameters.SortDescending)
            {
                AddOrderByDesc(x => sortField);
            }
            else
            {
                AddOrderBy(x => sortField);
            }
        }

        private void AddPaging(HotelSpecificationParams parameters)
        {
            // Ensure valid page size and page number
            parameters.PageSize = Math.Max(parameters.PageSize, 1); // Avoid page size of 0 or negative
            parameters.PageNumber = Math.Max(parameters.PageNumber, 1); // Avoid page number of 0 or negative

            AddSkip((parameters.PageNumber - 1) * parameters.PageSize);
            AddTake(parameters.PageSize);
        }

        private static readonly Dictionary<string, Func<Entities.Hotel, object>> SortByFields = new()
        {
            { "Rating", hotel => hotel.StarRating },
            { "Name", hotel => hotel.Name },
            { "City", hotel => hotel.City },
            { "Country", hotel => hotel.Country }
        };

        #endregion
    }
}
