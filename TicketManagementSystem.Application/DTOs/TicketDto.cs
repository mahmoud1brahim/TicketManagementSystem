using TicketManagementSystem.Domain.Enums;

namespace TicketManagementSystem.Application.DTOs
{
    public record TicketDto(
        Guid Id,
        DateTime CreationTime,
        string PhoneNumber,
        string Governorate,
        string City,
        string District,
        TicketStatus Status,
        TicketColor Color
    );
}
