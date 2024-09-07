using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.Application.Commands.CreateTicket;
using TicketManagementSystem.Application.Commands.HandleTicket;
using TicketManagementSystem.Application.Queries.GetTickets;

namespace TicketManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new ticket.
        /// </summary>
        /// <param name="command">The command containing ticket creation data.</param>
        /// <returns>The result of the creation process with the ID of the created ticket.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketId = await _mediator.Send(command);
            return StatusCode(201, ticketId);
        }

        /// <summary>
        /// Retrieves a paginated list of tickets.
        /// </summary>
        /// <param name="page">The page number to retrieve. Default is 1.</param>
        /// <param name="pageSize">The number of tickets per page. Default is 10.</param>
        /// <returns>A paginated list of tickets.</returns>
        [HttpGet]
        public async Task<IActionResult> GetTickets([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetTicketsQuery { Page = page, PageSize = pageSize };
            var tickets = await _mediator.Send(query);
            return Ok(tickets);
        }


        /// <summary>
        /// Marks a ticket as handled by its ID.
        /// </summary>
        /// <param name="id">The ID of the ticket to handle.</param>
        /// <returns>No content after handling the ticket.</returns>
        [HttpPut("{id}/handle")]
        public async Task<IActionResult> HandleTicket(Guid id)
        {
            var command = new HandleTicketCommand { Id = id };
            bool isHandled = await _mediator.Send(command);
            if (isHandled)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
