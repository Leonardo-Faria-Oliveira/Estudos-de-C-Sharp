using CRUDByBlazorTemplate.Dtos;
using CRUDByBlazorTemplate.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDByBlazorTemplate.Request
{
    public class PostRequest : BaseRequest
    {

        [JsonProperty("titulo")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("conteudo")]
        public ContentDto Content { get; set; }

        [JsonProperty("data_de_publicacao")]
        public DateTime PublishDateTime { get; set; }

        [JsonProperty("idCategoria")]
        public Guid CategoryId { get; set; }

        [JsonProperty("idUsuario")]
        public Guid UserId { get; set; }


    }
}
