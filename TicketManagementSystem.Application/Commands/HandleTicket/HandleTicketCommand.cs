using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TicketManagementSystem.Application.Commands.HandleTicket
{
    public class HandleTicketCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
