using Core.DTOs;
using Domain;

namespace Core.Interfaces.Factories;

public interface IPackageFactory
{
    // Converts a domain EventPackage to a display DTO PackageDisplay
    PackageDisplay ToDisplay(EventPackage packageDisplay);
    // Converts a display DTO PackageDisplay to a domain EventPackage
    EventPackage ToDomain(PackageDisplay packageDisplay);
}