using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Application.DTOs;

namespace TicketManagementSystem.Application.Queries.GetTickets
{
    public class GetTicketsQuery : IRequest<List<TicketDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
