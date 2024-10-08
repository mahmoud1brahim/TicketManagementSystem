﻿using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Infrastructure.Persistence
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=tickets.db");
            }
        }
    }
}
