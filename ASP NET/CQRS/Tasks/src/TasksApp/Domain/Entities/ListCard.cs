using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [Table("list_card")]
    internal class ListCard : BaseEntity
    {
        [Column("title")]
        [StringLength(35, MinimumLength = 10)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [Column("workspace_id")]
        [Required]
        public Guid WorkspaceId { get; set; }

        public required Workspace Workspace { get; set; }

        public ICollection<Card> Cards {get; set;} = [];
    }
}
