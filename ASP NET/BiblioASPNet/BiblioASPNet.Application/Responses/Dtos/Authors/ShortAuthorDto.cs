using Newtonsoft.Json;

namespace BiblioASPNet.Application.Responses.Dtos.Authors
{
    public record ShortAuthorDto(

            [JsonProperty("id")]
            Guid Id,

            [JsonProperty("name")]
            string Name,

            [JsonProperty("created_at")]
            DateTime CreatedAt  
    
    );
}
