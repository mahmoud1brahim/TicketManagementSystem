using Moq;
using TicketManagementSystem.Application.Commands.HandleTicket;
using TicketManagementSystem.Application.Interfaces;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.UnitTests.Commands
{
    public class HandleTicketCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnFalse_WhenTicketDoesNotExist()
        {
            // Arrange
            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(repo => repo.GetTicketByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Ticket)null); // Simulate ticket not found

            var handler = new HandleTicketCommandHandler(mockRepo.Object);
            var command = new HandleTicketCommand { Id = Guid.NewGuid() };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            mockRepo.Verify(repo => repo.GetTicketByIdAsync(It.IsAny<Guid>()), Times.Once);
            mockRepo.Verify(repo => repo.UpdateTicketAsync(It.IsAny<Ticket>()), Times.Never);
        }
    }
}

