using Core.DTOs;
using Core.Interfaces.Factories;
using Domain;

namespace Core.Factories.DTO;

public class EventDtoFactory : IEventDtoFactory
{
    public EventDisplay ToDisplay(Event displayEvent) =>
        new()
        {
            Id = displayEvent.Id,
            Title = displayEvent.Title,
            Description = displayEvent.Description,
            ImageId = displayEvent.ImageId,
            Location = displayEvent.Location,
            Category = displayEvent.Category,
            DateTime = displayEvent.DateTime,
            Price = displayEvent.Price,
        };

    public Event ToDomain(EventDisplay eventDisplay)
    {
        return new Event
        {
            Id = eventDisplay.Id,
            Title = eventDisplay.Title,
            Description = eventDisplay.Description,
            ImageId = eventDisplay.ImageId,
            Location = eventDisplay.Location,
            Category = eventDisplay.Category,
            DateTime = eventDisplay.DateTime,
            Price = eventDisplay.Price,
        };
    }
}
