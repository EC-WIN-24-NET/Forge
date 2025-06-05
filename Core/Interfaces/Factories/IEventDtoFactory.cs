using Core.DTOs;
using Domain;

namespace Core.Interfaces.Factories;

public interface IEventDtoFactory
{
    EventDisplay ToDisplay(Event displayEvent);
    Event ToDomain(EventDisplay eventDisplay);
}