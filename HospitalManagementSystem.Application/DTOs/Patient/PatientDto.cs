using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem.Application.DTOs.Patient
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}