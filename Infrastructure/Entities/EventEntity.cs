using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public class EventEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Title { get; set; } = null!;

    [Column(TypeName = "nvarchar(500)")]
    public string? Description { get; set; }

    [Column(TypeName = "nvarchar(36)")]
    public string? ImageId { get; set; }

    [Column(TypeName = "nvarchar(36)")]
    public string? Location { get; set; }

    [Column(TypeName = "int")]
    public ushort Category { get; set; } = 0;

    [DataType(DataType.DateTime)]
    public DateTime DateTime { get; set; }

    [Precision(18, 2)]
    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    // EF Core will typically set up a many-to-many relationship based on conventions
    // for ICollection on both sides.
    public virtual ICollection<EventPackageEntity> Packages { get; set; } =
        new List<EventPackageEntity>();
}
