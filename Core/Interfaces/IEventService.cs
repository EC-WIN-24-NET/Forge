using Core.DTOs;
using Domain;

namespace Core.Interfaces;

public interface IEventService
{
    Task<RepositoryResult<IEnumerable<EventDisplay>>> GetAllEventsAsync();
    Task<RepositoryResult<EventDisplay>> GetEventByGuid(Guid id);
}
