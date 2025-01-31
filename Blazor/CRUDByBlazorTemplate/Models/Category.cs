namespace CRUDByBlazorTemplate.Models
{
    public class Category : BaseModel
    {

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
