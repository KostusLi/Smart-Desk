using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public List<Booking> Bookings { get; set; } = new();
    }

    public enum Role
    {
        Admin,
        User
    }
}
