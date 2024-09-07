using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Application.Interfaces;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Infrastructure.Persistence.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDbContext _context;

        public TicketRepository(TicketDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket.Id;
        }

        public async Task<List<Ticket>> GetTicketsAsync(int page, int pageSize)
        {
            return await _context.Tickets
                .OrderByDescending(t => t.CreationTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(Guid id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
