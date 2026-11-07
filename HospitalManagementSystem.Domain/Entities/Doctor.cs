using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem.Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Speciality { get; set; } 
        public required string PhoneNumber { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
