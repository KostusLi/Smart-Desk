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
        public string UserName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Booking(Guid RoomId, string UserName, DateTime StartTime, DateTime EndTime)
        {
            this.RoomId = RoomId;
            this.Room = Room;
            this.UserName = UserName;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }

        public Booking() { }
    }
}
