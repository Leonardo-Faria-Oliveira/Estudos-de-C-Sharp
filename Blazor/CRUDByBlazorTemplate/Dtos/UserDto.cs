using Newtonsoft.Json;

namespace CRUDByBlazorTemplate.Dtos
{
    public class UserDto : BaseDto
    {

        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;

        [JsonProperty("senhaa")]
        public string Password { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("nome_completo")]
        public string FullName { get; set; } = string.Empty;

        [JsonProperty("avatar")]
        public string Avatar { get; set; } = string.Empty;

        [JsonProperty("role")]
        public int Role { get; set; }

    }

}
