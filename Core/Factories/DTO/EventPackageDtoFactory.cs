using Core.DTOs;
using Core.Interfaces.Factories;
using Domain;

namespace Core.Factories.DTO;

public class EventPackageDtoFactory : IEventPackageFactory
{
    public PackageDisplay? ToDisplay(EventPackage? packageDisplay)
    {
        if (packageDisplay == null)
            return null;
        return new PackageDisplay
        {
            Id = packageDisplay.Id,
            Title = packageDisplay.Title,
            Description = packageDisplay.Description,
            Perks = packageDisplay.Perks,
            Price = packageDisplay.Price,
            Currency = packageDisplay.Currency,
        };
    }

    public EventPackage? ToDomain(PackageDisplay? packageDisplay)
    {
        if (packageDisplay == null)
            return null;
        return new EventPackage
        {
            Id = packageDisplay.Id,
            Title = packageDisplay.Title,
            Description = packageDisplay.Description,
            Perks = packageDisplay.Perks,
            Price = packageDisplay.Price,
            Currency = packageDisplay.Currency,
        };
    }
}
