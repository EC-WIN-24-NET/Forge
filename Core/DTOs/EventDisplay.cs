using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class EventDisplay
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
    public string Title { get; set; } = null!;
    public uint ImageId { get; set; } = 0;
    public uint Location { get; set; } = 0;
    public ushort Category { get; set; } = 0;
    [Required]
    public DateTime DateTime { get; set; }
    [Required]
    public decimal Price { get; set; }
}
