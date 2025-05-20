using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("user")]
    internal class User : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("surname")]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; } = string.Empty;

        [Column("email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Column("password_hash")]
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("username")]
        [Required]
        [StringLength(12)]
        public string Username { get; set; } = string.Empty;

        [Column("refresh_token")]
        public string RefreshToken { get; set; } = string.Empty;

        [Column("refresh_expiration_time")]
        public DateTime RefreshExpirationTime { get; set; }

        [Column("is_active")]
        [Required]
        public override bool IsActive { get; set; } = false;

        public ICollection<Workspace> Workspaces { get; set; } = [];

    }
}
