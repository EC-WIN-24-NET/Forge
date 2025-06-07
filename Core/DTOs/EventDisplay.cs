using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class EventDisplay
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? ImageId { get; set; }
    public string? Location { get; set; }
    public ushort Category { get; set; } = 0;

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public decimal Price { get; set; }
}
