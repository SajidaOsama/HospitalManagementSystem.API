using System;
using System.Collections.Generic;
using System.Text;
namespace HospitalManagementSystem.Application.DTOs
{
    public class UpdateAppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}