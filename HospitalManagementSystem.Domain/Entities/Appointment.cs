using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "Scheduled"; //  (Scheduled, Completed, Cancelled)

        // Foreign Keys
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int ReceptionistId { get; set; }
        public Receptionist Receptionist { get; set; } = null!;
    
}
}
