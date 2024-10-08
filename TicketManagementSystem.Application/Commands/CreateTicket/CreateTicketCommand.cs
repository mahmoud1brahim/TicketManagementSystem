﻿using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TicketManagementSystem.Application.Commands.CreateTicket
{
    public class CreateTicketCommand : IRequest<Guid>
    {
        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public required string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Governorate is required.")]
        public required string Governorate { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public required string City { get; set; }

        [Required(ErrorMessage = "District is required.")]
        public required string District { get; set; }
    }
}
