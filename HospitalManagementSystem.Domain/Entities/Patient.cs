using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public  required string PhoneNumber { get; set; }
        public required string Gender { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
