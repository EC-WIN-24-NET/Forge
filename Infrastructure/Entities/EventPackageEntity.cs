using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public class EventPackageEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Title { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(300)")]
    public string? Description { get; set; } = null!;

    [StringLength(500)]
    [Column(TypeName = "nvarchar(max)")]
    public string? Perks { get; set; }

    [Precision(18, 2)]
    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(3)")]
    public string Currency { get; set; } = "SEK";
    public virtual ICollection<EventEntity> Events { get; set; } = new List<EventEntity>();
}
