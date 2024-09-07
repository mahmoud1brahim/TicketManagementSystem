using MediatR;
using TicketManagementSystem.Application.DTOs;

namespace TicketManagementSystem.Application.Queries.GetTickets
{
    public class GetTicketsQuery : IRequest<List<TicketDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
