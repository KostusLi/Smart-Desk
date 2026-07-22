using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTOs
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsActive { get; set; }

        public RoomDto(Guid id, string name, int capacity, bool isActive) 
        { Id = id; Name = name; Capacity = capacity; IsActive = isActive; }
    }
}
