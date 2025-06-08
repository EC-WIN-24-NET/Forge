using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class PackageDisplay
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Perks { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string Currency { get; set; } = "SEK";
}
