using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Domain.Entities;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Receptionist)
                .ToListAsync();

            return appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,
                PatientId = a.PatientId,
                PatientName = a.Patient.Name,
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor.Name,
                ReceptionistId = a.ReceptionistId,
                ReceptionistName = a.Receptionist.Name
            });
        }

        public async Task<AppointmentDto?> GetAppointmentByIdAsync(Guid id)
        {
            var a = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Receptionist)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (a == null) return null;

            return new AppointmentDto
            {
                Id = a.Id,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,
                PatientId = a.PatientId,
                PatientName = a.Patient.Name,
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor.Name,
                ReceptionistId = a.ReceptionistId,
                ReceptionistName = a.Receptionist.Name
            };
        }

        public async Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto dto)
        {
            var appointment = new Appointment
            {
                AppointmentDate = dto.AppointmentDate,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                ReceptionistId = dto.ReceptionistId,
                Status = "Scheduled"
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            var created = await _context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .Include(x => x.Receptionist)
                .FirstAsync(x => x.Id == appointment.Id);

            return new AppointmentDto
            {
                Id = created.Id,
                AppointmentDate = created.AppointmentDate,
                Status = created.Status,
                PatientId = created.PatientId,
                PatientName = created.Patient.Name,
                DoctorId = created.DoctorId,
                DoctorName = created.Doctor.Name,
                ReceptionistId = created.ReceptionistId,
                ReceptionistName = created.Receptionist.Name
            };
        }

        public async Task UpdateAppointmentAsync(Guid id, UpdateAppointmentDto dto)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                appointment.AppointmentDate = dto.AppointmentDate;
                appointment.Status = dto.Status;

                _context.Appointments.Update(appointment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAppointmentAsync(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}