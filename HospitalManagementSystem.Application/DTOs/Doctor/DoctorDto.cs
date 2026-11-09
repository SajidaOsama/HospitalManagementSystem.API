using System;
using System.Collections.Generic;
using System.Text;
namespace HospitalManagementSystem.Application.DTOs.Doctor
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}