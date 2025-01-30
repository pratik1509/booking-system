using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.API.Infrastructure.Specifications
{
    public class RoomSpecificationParams
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Type { get; set; }
        public Guid? HotelId { get; set; }

        // Pagination
        public int PageSize { get; set; } = 10;  // Default page size
        public int PageNumber { get; set; } = 1;  // Default page number

        // Sorting
        public string SortBy { get; set; } = "Price";  // Default sorting field
        public bool SortDescending { get; set; } = false;  // Default sort direction (ascending)
    }
}