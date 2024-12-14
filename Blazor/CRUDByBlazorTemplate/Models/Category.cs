namespace CRUDByBlazorTemplate.Models
{
    public class Category : BaseModel
    {
        public Category(string _title, string _description)
        {
            Title = _title;
            Description = _description;
        }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
