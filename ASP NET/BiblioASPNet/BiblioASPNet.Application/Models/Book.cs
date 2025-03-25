namespace BiblioASPNet.Application.Models
{
    public class Book : BaseModel
    {

        public string Title { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }

        public Author Author { get; set; } = default!;

    }
}
