using Domain;
using Infrastructure.Entities;

namespace Infrastructure.Factories;

public class PackageFactory : EntityFactoryBase<EventPackage, EventPackageEntity>
{
    /// <summary>
    /// Creating from Entity object to Domain object
    /// Entity -> Domain
    /// </summary>
    /// <param name="eventPackageEntity"></param>
    /// <returns></returns>
    public override EventPackage ToDomain(EventPackageEntity eventPackageEntity) =>
        new()
        {
            Id = eventPackageEntity.Id,
            Title = eventPackageEntity.Title,
            Description = eventPackageEntity.Description,
            Perks = eventPackageEntity.Perks,
            Price = eventPackageEntity.Price,
            Currency = eventPackageEntity.Currency,
        };

    /// <summary>
    /// Creating from Domain object to Entity object
    /// Domain -> Entity
    /// </summary>
    /// <param name="eventPackage"></param>
    /// <returns></returns>
    public override EventPackageEntity ToEntity(EventPackage eventPackage) =>
        new()
        {
            Id = eventPackage.Id,
            Title = eventPackage.Title,
            Description = eventPackage.Description,
            Perks = eventPackage.Perks,
            Price = eventPackage.Price,
            Currency = eventPackage.Currency,
            Events = eventPackage.Events.Select(e => new EventFactory().ToEntity(e)).ToList(),
        };
}
