using BiblioASPNet.Application.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;

namespace BiblioASPNet.Application.Responses.Dtos.Books
{
    public record ShortBookDto(

        [JsonProperty("id")]
        Guid Id,

        [JsonProperty("title")]
        string Title,

        [JsonProperty("authorId")]
        Guid AuthorId,

        [JsonProperty("created_at")]
        DateTime CreatedAt,

        [JsonProperty("updated_at")]
        DateTime UpdatedAt

    );
}
