using System;
using System.Collections.Generic;
using System.Text;
namespace HospitalManagementSystem.Application.DTOs
{
    public class CreateDoctorDto
    {
        public string Name { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}