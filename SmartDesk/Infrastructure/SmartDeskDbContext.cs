using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class SmartDeskDbContext : DbContext, ISmartDeskDbContext
    {
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;


        public SmartDeskDbContext(DbContextOptions<SmartDeskDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmartDeskDbContext).Assembly);
        }

    }

}
