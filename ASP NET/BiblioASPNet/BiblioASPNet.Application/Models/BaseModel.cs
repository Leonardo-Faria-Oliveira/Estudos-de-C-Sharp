using System.ComponentModel.DataAnnotations;

namespace BiblioASPNet.Application.Models
{
    public abstract class BaseModel
    {

        [Key]
        public virtual Guid Id { get; set; } = Guid.NewGuid();

        public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
