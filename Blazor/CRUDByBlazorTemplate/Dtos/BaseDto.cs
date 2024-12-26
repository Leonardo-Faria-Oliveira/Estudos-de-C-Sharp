using Newtonsoft.Json;

namespace CRUDByBlazorTemplate.Dtos
{
    public abstract class BaseDto
    {

        [JsonProperty("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [JsonProperty("criado_em")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonProperty("ultima_atualizacao_em")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
