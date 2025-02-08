using CRUDByBlazorTemplate.Models;
using Newtonsoft.Json;

namespace CRUDByBlazorTemplate.Dtos
{
    public class ContentDto : BaseDto
    {


        [JsonProperty("texto")]
        public string Text { get; set; } = string.Empty;


        [JsonProperty("imagem")]
        public string Image { get; set; } = string.Empty;


        [JsonProperty("video")]
        public string Video { get; set; } = string.Empty;



    }
}
