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
            Description = eventEntity.Description,
            ImageId = eventEntity.ImageId,
            Location = eventEntity.Location,
            Category = eventEntity.Category,
            DateTime = eventEntity.DateTime,
            Price = eventEntity.Price,
            // Convert each package entity to a domain object using PackageFactory
            // The bad side that EFcore need to populate the packages
            Packages = eventEntity.Packages.Select(p => new PackageFactory().ToDomain(p)).ToList(),
        };

    /// <summary>
    /// Creating from Domain object to Entity object
    /// Domain -> Entity
    /// </summary>
    /// <param name="events"></param>
    /// <returns></returns>
    public override EventEntity ToEntity(Event events) =>
        new()
        {
            Id = events.Id,
            Title = events.Title,
            Description = events.Description,
            ImageId = events.ImageId,
            Location = events.Location,
            Category = events.Category,
            DateTime = events.DateTime,
            Price = events.Price,
            Packages = events.Packages.Select(p => new PackageFactory().ToEntity(p)).ToList(),
        };
}
