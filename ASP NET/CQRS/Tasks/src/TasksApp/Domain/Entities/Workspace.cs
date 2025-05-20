using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("workspace")]
    internal class Workspace : BaseEntity
    {
        [Column("title")]
        [StringLength(35, MinimumLength = 10)]
        public string Title { get; set; } = string.Empty;

        [Column("user_id")]
        public Guid UserId { get; set; }

        public required User User { get; set; }

        public ICollection<ListCard> Tasks { get; set; } = [];

     

    }
}
