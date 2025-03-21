using System.Text.Json.Serialization;

namespace BiblioASPNet.Application.Models
{
    public class Author : BaseModel
    {

        public string Name { get; set; } = string.Empty;

        public string? About { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Book> Books { get; set; }

    }
}
