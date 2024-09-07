using MediatR;
using TicketManagementSystem.Application.Interfaces;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Application.Commands.CreateTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
    {
        private readonly ITicketRepository _repository;

        public CreateTicketCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket(request.PhoneNumber, request.Governorate, request.City, request.District);
            return await _repository.CreateTicketAsync(ticket);
        }
    }
}
