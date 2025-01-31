namespace CRUDByBlazorTemplate.Models
{
    public class Content : BaseModel
    {

        public string Text { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public string Video { get; set; } = string.Empty;

        public Guid PostId { get; set; }

        public Post Post { get; set; }

    }
}
