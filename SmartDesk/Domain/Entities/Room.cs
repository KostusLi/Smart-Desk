using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
        public List<Booking> Bookings { get; set; } = new();

        public Room() { }
    }
}
