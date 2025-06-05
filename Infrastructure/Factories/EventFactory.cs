using Domain;
using Infrastructure.Entities;

namespace Infrastructure.Factories;

/// <summary>
/// Event Factory
/// </summary>
public class EventFactory : EntityFactoryBase<Event, EventEntity>
{
    /// <summary>
    /// Creating from Entity object to Domain object
    /// Entity -> Domain
    /// </summary>
    /// <param name="eventEntity"></param>
    /// <returns></returns>
    public override Event ToDomain(EventEntity eventEntity) =>
        new()
        {
            Id = eventEntity.Id,
            Title = eventEntity.Title,
            ImageId = eventEntity.ImageId,
            Location = eventEntity.Location,
            Category = eventEntity.Category,
            DateTime = eventEntity.DateTime,
            Price = eventEntity.Price,
        };

    /// <summary>
    /// Creating from Domain object to Entity object
    /// Domain -> Entity
    /// </summary>
    /// <param name="users"></param>
    /// <param name="events"></param>
    /// <returns></returns>
    public override EventEntity ToEntity(Event events) =>
        new()
        {
            Id = events.Id,
            Title = events.Title,
            ImageId = events.ImageId,
            Location = events.Location,
            Category = events.Category,
            DateTime = events.DateTime,
            Price = events.Price,
        };
}
