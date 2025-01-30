using BuildingBlocks.RepositorySpecification.Specification;
using Hotel.API.Infrastructure.Entities;

namespace Hotel.API.Infrastructure.Specifications
{
    public class RoomByPriceTypeSpecification : Specification<Room>
    {
        public RoomByPriceTypeSpecification(RoomSpecificationParams parameters)
        : base(room => (!parameters.MinPrice.HasValue || room.PricePerNight >= parameters.MinPrice.Value) &&
                       (!parameters.MaxPrice.HasValue || room.PricePerNight <= parameters.MaxPrice.Value))
        {
            AddSorting(parameters);
            AddPaging(parameters);
        }

        #region Private Methods

        private void AddSorting(RoomSpecificationParams parameters)
        {
            if (!string.IsNullOrEmpty(parameters.SortBy))
            {
                if (parameters.SortDescending)
                {
                    AddOrderByDesc(room => room.PricePerNight);
                }
                else
                {
                    AddOrderBy(room => room.PricePerNight);
                }
            }
        }

        private void AddPaging(RoomSpecificationParams parameters)
        {
            AddSkip((parameters.PageNumber - 1) * parameters.PageSize);
            AddTake(parameters.PageSize);
        }

        #endregion
    }
}