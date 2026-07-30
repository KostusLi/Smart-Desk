using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ISmartDeskDbContext
    {
        public DbSet<Room> Rooms { get; }
        public DbSet<Booking> Bookings { get; }
        public DbSet<User> Users { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
