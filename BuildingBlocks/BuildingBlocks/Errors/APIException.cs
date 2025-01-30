namespace BuildingBlocks.Errors
{
    public class APIException(int statusCode, string? message = null, string? details = null)
    : ApiResponse(statusCode, message)
    {
        public string? Details { get; set; } = details;
    }
}