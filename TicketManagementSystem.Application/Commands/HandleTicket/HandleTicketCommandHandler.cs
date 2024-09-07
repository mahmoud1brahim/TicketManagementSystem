using MediatR;
using TicketManagementSystem.Application.Interfaces;

namespace TicketManagementSystem.Application.Commands.HandleTicket
{
    public class HandleTicketCommandHandler : IRequestHandler<HandleTicketCommand, bool>
    {
        private readonly ITicketRepository _repository;

        public HandleTicketCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(HandleTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetTicketByIdAsync(request.Id);

            if (ticket == null)
            {
                return false; // Ticket not found
            }

            ticket.Handle();
            await _repository.UpdateTicketAsync(ticket);
            return true;
        }
    }
}
