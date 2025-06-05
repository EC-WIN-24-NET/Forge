using Core.Interfaces.Data;
using Core.Interfaces.Factories;
using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repository.Event;

public class EventRepository(
    DataContext dataContext,
    IEntityFactory<Domain.Event?, EventEntity> factory,
    IRepositoryResultFactory resultFactory
) : BaseRepository<Domain.Event, EventEntity>(dataContext, factory, resultFactory), IEventRepository
{
    // If we want to override the methods from the BaseRepository
    // using override keyword, remember that the method needs to be virtual in the BaseRepository
}
