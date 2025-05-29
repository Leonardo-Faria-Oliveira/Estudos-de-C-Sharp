using System.Security.Cryptography.X509Certificates;

namespace Domain.Adapters.Responses
{
    public record ResponseInfo(
        string? Message,
        string? Error,
        int StatusCode
    );
}
