using Newtonsoft.Json;

namespace BiblioASPNet.Application.Requests.Books
{
    public record UpdateBookRequest
    (
         [JsonProperty("title")]
        string Title,
        [JsonProperty("author_id")]
        Guid AuthorId
        ) : BaseRequest;
}
