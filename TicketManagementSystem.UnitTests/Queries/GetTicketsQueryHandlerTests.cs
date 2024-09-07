using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Application.Interfaces;
using TicketManagementSystem.Application.Queries.GetTickets;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.UnitTests.Queries
{
    public class GetTicketsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnTickets_WhenQueryIsValid()
        {
            // Arrange
            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(repo => repo.GetTicketsAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new List<Ticket>
                {
                    new Ticket("1234567890", "Gov1", "City1", "District1"),
                    new Ticket("0987654321", "Gov2", "City2", "District2")
                });

            var handler = new GetTicketsQueryHandler(mockRepo.Object);
            var query = new GetTicketsQuery { Page = 1, PageSize = 10 };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
            mockRepo.Verify(repo => repo.GetTicketsAsync(1, 10), Times.Once);
        }
    }
}
