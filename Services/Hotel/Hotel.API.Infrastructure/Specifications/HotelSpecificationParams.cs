namespace Hotel.API.Infrastructure.Specifications
{
    public class HotelSpecificationParams
    {
        public string? Location { get; set; }
        public int? Rating { get; set; }
        public string? Name { get; set; }

        // Pagination
        public int PageSize { get; set; } = 10;  // Default page size
        public int PageNumber { get; set; } = 1;  // Default page number

        // Sorting
        public string SortBy { get; set; } = "Name";  // Default sorting field
        public bool SortDescending { get; set; } = false;  // Default sort direction (ascending)
    }
}