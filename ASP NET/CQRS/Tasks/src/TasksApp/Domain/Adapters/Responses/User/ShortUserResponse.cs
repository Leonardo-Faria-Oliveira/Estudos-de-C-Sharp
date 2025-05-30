namespace Domain.Adapters.Responses.User
{
    public record ShortUserResponse(
        string Name,
        string Surname,
        string Username,
        string Email
        
    ) : TResponse;
        
}
