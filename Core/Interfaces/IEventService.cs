using Core.DTOs;
using Domain;

namespace Core.Interfaces;

public interface IEventService
{
    Task<RepositoryResult<EventDisplay>> GetAllEventsAsync();
    Task<RepositoryResult<EventDisplay>> GetEventByGuid(Guid id);
}