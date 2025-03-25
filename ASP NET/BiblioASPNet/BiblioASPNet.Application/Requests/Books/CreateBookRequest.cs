using Newtonsoft.Json;

namespace BiblioASPNet.Application.Requests.Books
{
    public record CreateBookRequest
    (
         [JsonProperty("title")]
        string Title,
        [JsonProperty("author_id")]
        Guid AuthorId
        ) : BaseRequest;
}
