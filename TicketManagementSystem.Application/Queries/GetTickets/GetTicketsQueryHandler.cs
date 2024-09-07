using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Application.DTOs;
using TicketManagementSystem.Application.Interfaces;

namespace TicketManagementSystem.Application.Queries.GetTickets
{
    public class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, List<TicketDto>>
    {
        private readonly ITicketRepository _repository;

        public GetTicketsQueryHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TicketDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _repository.GetTicketsAsync(request.Page, request.PageSize);
            return tickets.Select(t => new TicketDto(
                t.Id,
                t.CreationTime,
                t.PhoneNumber,
                t.Governorate,
                t.City,
                t.District,
                t.Status,
                t.GetColor()
            )).ToList();
        }
    }
}
