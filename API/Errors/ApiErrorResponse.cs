
namespace API.Errors;
internal class ApiErrorResponse(int StatusCode, string Message, string? Details) {
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string? Details { get; set; }
}

