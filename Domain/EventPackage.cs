namespace Domain;

public class EventPackage
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Perks { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; } = "SEK";
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
