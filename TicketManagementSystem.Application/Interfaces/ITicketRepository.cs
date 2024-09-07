using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Application.Interfaces
{
    public interface ITicketRepository
    {
        Task<Guid> CreateTicketAsync(Ticket ticket);
        Task<List<Ticket>> GetTicketsAsync(int page, int pageSize);
        Task<Ticket> GetTicketByIdAsync(Guid id);
        Task UpdateTicketAsync(Ticket ticket);
    }
}
