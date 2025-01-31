using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDByBlazorTemplate.Models
{
    public class Post : BaseModel
    {

        public string Title { get; set; } = string.Empty;

        public Content Content { get; set; }
        
        public DateTime PublishDateTime { get; set; }

        public Guid CategoryId { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
