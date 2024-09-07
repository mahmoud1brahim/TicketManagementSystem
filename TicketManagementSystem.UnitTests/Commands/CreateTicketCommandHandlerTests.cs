using Moq;
using TicketManagementSystem.Application.Commands.CreateTicket;
using TicketManagementSystem.Application.Interfaces;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.UnitTests.Commands
{
    public class CreateTicketCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateTicket_WhenCommandIsValid()
        {
            // Arrange
            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(repo => repo.CreateTicketAsync(It.IsAny<Ticket>()))
                .ReturnsAsync(Guid.NewGuid());

            var handler = new CreateTicketCommandHandler(mockRepo.Object);
            var command = new CreateTicketCommand
            {
                PhoneNumber = "1234567890",
                Governorate = "Test Governorate",
                City = "Test City",
                District = "Test District"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            mockRepo.Verify(repo => repo.CreateTicketAsync(It.IsAny<Ticket>()), Times.Once);
        }

    }
}