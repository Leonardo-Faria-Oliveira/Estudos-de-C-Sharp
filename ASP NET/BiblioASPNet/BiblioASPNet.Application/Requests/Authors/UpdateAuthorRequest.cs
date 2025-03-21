using BiblioASPNet.Application.Requests;
using Newtonsoft.Json;

namespace BiblioASPNet.Application.Requests.Authors
{
    public record UpdateAuthorRequest(
        [JsonProperty("name")]
        string Name,
        [JsonProperty("about")]
        string About
    ) : BaseRequest;
}
