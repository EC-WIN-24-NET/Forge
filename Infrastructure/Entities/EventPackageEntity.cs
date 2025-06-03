namespace Infrastructure.Entities;

public class EventPackageEntity
{
    public uint Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Perks { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; } = "SEK";
    public virtual ICollection<EventEntity> Events { get; set; } = new List<EventEntity>();
}
