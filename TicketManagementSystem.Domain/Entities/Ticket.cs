using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Domain.Enums;

namespace TicketManagementSystem.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; private set; }
        public DateTime CreationTime { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Governorate { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }
        public TicketStatus Status { get; private set; }

        public Ticket(string phoneNumber, string governorate, string city, string district)
        {
            Id = Guid.NewGuid();
            CreationTime = DateTime.UtcNow;
            PhoneNumber = phoneNumber;
            Governorate = governorate;
            City = city;
            District = district;
            Status = TicketStatus.New;
        }

        public void Handle()
        {
            Status = TicketStatus.Handled;
        }

        public TicketColor GetColor()
        {
            var timeSinceCreation = DateTime.UtcNow - CreationTime;

            if (timeSinceCreation <= TimeSpan.FromMinutes(15))
                return TicketColor.Yellow;
            else if (timeSinceCreation <= TimeSpan.FromMinutes(30))
                return TicketColor.Green;
            else if (timeSinceCreation <= TimeSpan.FromMinutes(45))
                return TicketColor.Blue;
            else
                return TicketColor.Red;
        }
    }
}
