using CRUDByBlazorTemplate.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDByBlazorTemplate.Dtos
{
    public class PostDto : BaseDto
    {

        [JsonProperty("titulo")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("conteudo")]
        public ContentDto Content { get; set; }

        [JsonProperty("data_de_publicacao")]
        public DateTime PublishDateTime { get; set; }

        [JsonProperty("categoria")]
        [ForeignKey("CategoryId")]
        public CategoryDto Category { get; set; }

        [JsonProperty("usuario")]
        [ForeignKey("UserId")]
        public UserDto User { get; set; }

    }
}
