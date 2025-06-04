using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public class EventPackageEntity
{
    [Key]
    public uint Id { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    public string? Perks { get; set; }
    [Precision(18, 2)]
    public decimal Price { get; set; }
    public string Currency { get; set; } = "SEK";
    public virtual ICollection<EventEntity> Events { get; set; } = new List<EventEntity>();
}
