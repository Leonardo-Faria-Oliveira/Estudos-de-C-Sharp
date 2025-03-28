using Newtonsoft.Json;

namespace BiblioASPNet.Application.Responses.Dtos.Authors
{
    public record AuthorDetailsDto(

         [JsonProperty("id")]
         Guid Id,

         [JsonProperty("name")]
         string Name,

         [JsonProperty("about")]
         string About,

        [JsonProperty("created_at")]
        DateTime CreatedAt,

        [JsonProperty("updated_at")]
        DateTime UpdatedAt

    );
}
