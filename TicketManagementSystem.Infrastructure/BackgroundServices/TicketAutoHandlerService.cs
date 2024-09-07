using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Application.Commands.HandleTicket;
using TicketManagementSystem.Application.Interfaces;
using TicketManagementSystem.Domain.Enums;

namespace TicketManagementSystem.Infrastructure.BackgroundServices
{
    public class TicketAutoHandlerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public TicketAutoHandlerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    var repository = scope.ServiceProvider.GetRequiredService<ITicketRepository>();

                    var tickets = await repository.GetTicketsAsync(1, int.MaxValue);
                    var ticketsToHandle = tickets.Where(t => t.Status == TicketStatus.New && (DateTime.UtcNow - t.CreationTime) >= TimeSpan.FromMinutes(60));

                    foreach (var ticket in ticketsToHandle)
                    {
                        await mediator.Send(new HandleTicketCommand { Id = ticket.Id });
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
