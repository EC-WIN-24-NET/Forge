using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Infrastructure.Entities;

public class EventEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public uint ImageId { get; set; } = 0;
    public uint Location { get; set; } = 0;
    public ushort Category { get; set; } = 0;
    public DateTime DateTime { get; set; }
    public SqlMoney Price { get; set; } = SqlMoney.Zero;
    public virtual ICollection<EventPackageEntity> Packages { get; set; } =
        new List<EventPackageEntity>();
}
