namespace Domain;

public class Event
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? ImageId { get; set; }
    public string? Location { get; set; }
    public ushort Category { get; set; } = 0;
    public DateTime DateTime { get; set; }
    public decimal Price { get; set; }

    // EF Core will typically set up a many-to-many relationship based on conventions
    // for ICollection on both sides.
    public virtual ICollection<EventPackage> Packages { get; set; } = new List<EventPackage>();
}
