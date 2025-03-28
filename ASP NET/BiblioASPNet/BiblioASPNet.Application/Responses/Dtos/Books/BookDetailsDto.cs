using BiblioASPNet.Application.Responses.Dtos.Authors;
using Newtonsoft.Json;

namespace BiblioASPNet.Application.Responses.Dtos.Books
{
    public record BookDetailsDto(

        [JsonProperty("id")]
        Guid Id,

        [JsonProperty("title")]
        string Title,

        [JsonProperty("author")]
        AuthorDetailsDto Author,

        [JsonProperty("created_at")]
        DateTime CreatedAt,

        [JsonProperty("updated_at")]
        DateTime UpdatedAt

    );
}
