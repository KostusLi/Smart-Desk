using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Booking(Guid RoomId, Guid? UserId, DateTime StartTime, DateTime EndTime)
        {
            this.RoomId = RoomId;
            this.UserId = UserId;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }

        public Booking() { }
    }
}
