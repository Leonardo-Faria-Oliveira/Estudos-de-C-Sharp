using Newtonsoft.Json;
using System.Runtime.Serialization;
using BiblioASPNet.Application.Utils.Attributes;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Serialization;

namespace BiblioASPNet.Application.Requests.Authors
{
    public record CreateAuthorRequest : BaseRequest
    {
        public CreateAuthorRequest(string Name, string? About)
        {
            this.Name = Name;
            this.About = About;
        }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("about")]
        [NullableField]
        public string About { get; set; } = string.Empty;

    }
        
}
