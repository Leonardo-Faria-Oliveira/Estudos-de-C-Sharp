using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        [Required]
        public Guid Id { get; set; }

        [Column("is_active")]
        public virtual bool IsActive { get; set; } = true;

        [Column("created_at")]
        public virtual DateTimeOffset CreatedAt { get; set; }

        [Column("updated_at")]
        public virtual DateTimeOffset UpdateAt { get; set; }

    }
}
