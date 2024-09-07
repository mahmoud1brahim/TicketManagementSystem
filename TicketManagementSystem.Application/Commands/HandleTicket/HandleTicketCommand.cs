using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Application.Commands.HandleTicket
{
    public class HandleTicketCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
