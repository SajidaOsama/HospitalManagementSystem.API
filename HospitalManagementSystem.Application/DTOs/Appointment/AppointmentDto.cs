using System;
using System.Collections.Generic;
using System.Text;
namespace HospitalManagementSystem.Application.DTOs.Appointment
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = string.Empty;

        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;

        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;

        public int ReceptionistId { get; set; }
        public string ReceptionistName { get; set; } = string.Empty;
    }
}