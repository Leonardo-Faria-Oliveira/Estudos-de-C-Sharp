using Newtonsoft.Json;

namespace CRUDByBlazorTemplate.Dtos
{
    public class CategoryDto : BaseDto
    {
    
        [JsonProperty("titulo")]
        public string Title { get; set; }

        [JsonProperty("descricao")]
        public string Description { get; set; }
     
    }
}
