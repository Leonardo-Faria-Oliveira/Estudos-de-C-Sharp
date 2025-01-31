namespace CRUDByBlazorTemplate.Models
{
    public class User : BaseModel
    {

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Avatar { get; set; } = string.Empty;

        public int Role { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();

    }
}
