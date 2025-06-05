using System.Data.Common;
using Core.DTOs;
using Core.Interfaces;
using Core.Interfaces.Data;
using Core.Interfaces.Factories;
using Domain;

namespace Core.Services;

public class EventService(
    IEventRepository eventRepository,
    IRepositoryResultFactory resultFactory,
    IEventDtoFactory eventDtoFactory
) : IEventService
{
    public Task<RepositoryResult<EventDisplay>> GetAllEventsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<RepositoryResult<EventDisplay>> GetEventByGuid(Guid id)
    {
        try
        {
            // Get the event from the repository
            var eventResult = await eventRepository.GetAsync(e => e != null && e.Id == id, false);

            // Check if the result is successful
            if (eventResult.StatusCode != 200 || eventResult.Value == null)
            {
                // Return the error using RepositoryResult
                return resultFactory.OperationFailed<EventDisplay>(
                    eventResult.Error,
                    eventResult.StatusCode
                );
            }

            // Return the created domain object and success result
            var displayUserDto = eventDtoFactory.ToDisplay(eventResult.Value);
            return resultFactory.OperationSuccess(displayUserDto, 200);
        }
        catch (Exception)
        {
            // Log the exception ex (recommended)
            return resultFactory.OperationFailed<EventDisplay>(
                new Error(
                    "Event.RetrievalError",
                    "An unexpected error occurred while retrieving user details."
                ),
                500 // Internal Server Error
            );
        }
    }
}
