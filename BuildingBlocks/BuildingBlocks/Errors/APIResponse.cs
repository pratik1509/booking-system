namespace BuildingBlocks.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made.",
                401 => "Authorized, you are not.",
                404 => "The resource you seek, found it was not.",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to a career change.",
                _ => string.Empty
            };
        }
    }
}