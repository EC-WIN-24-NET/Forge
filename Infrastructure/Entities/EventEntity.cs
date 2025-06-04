using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public class EventEntity
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    public uint ImageId { get; set; } = 0;
    public uint Location { get; set; } = 0;
    public ushort Category { get; set; } = 0;
    public DateTime DateTime { get; set; }
    [Precision(18, 2)]
    public decimal Price { get; set; }
    public virtual ICollection<EventPackageEntity> Packages { get; set; } =
        new List<EventPackageEntity>();
}
