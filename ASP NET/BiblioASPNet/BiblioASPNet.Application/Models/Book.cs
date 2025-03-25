namespace BiblioASPNet.Application.Models
{
    public class Book : BaseModel
    {

        public string Title { get; set; } = string.Empty;

        public required Author Author { get; set; }

    }
}
