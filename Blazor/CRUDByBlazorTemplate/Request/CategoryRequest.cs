using Newtonsoft.Json;

namespace CRUDByBlazorTemplate.Request
{
    public class CategoryRequest : BaseRequest
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

    }
}
