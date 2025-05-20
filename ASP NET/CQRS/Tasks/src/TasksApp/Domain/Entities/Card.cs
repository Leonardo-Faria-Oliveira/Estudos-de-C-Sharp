using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [Table("card")]
    internal class Card : BaseEntity
    {
        [Column("title")]
        [StringLength(35, MinimumLength = 10)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [Column("description")]
        [StringLength(1200, MinimumLength = 200)]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Column("deadline")]
        public DateTime Deadline { get; set; }

        [Column("status")]
        [Required]
        public ECardStatus Status { get; set; }

        [Column("list_card_id")]
        [Required]
        public Guid ListCardId { get; set; }

        public required ListCard ListCard { get; set; }

    }
}
