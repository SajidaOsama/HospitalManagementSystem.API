using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Domain.Entities;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;

        public DoctorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                Name = d.Name,
                Speciality = d.Speciality, // تم التعديل لتطابق الدومين
                PhoneNumber = d.PhoneNumber
            });
        }

        public async Task<DoctorDto?> GetDoctorByIdAsync(int id)
        {
            var d = await _context.Doctors.FindAsync(id);
            if (d == null) return null;

            return new DoctorDto
            {
                Id = d.Id,
                Name = d.Name,
                Speciality = d.Speciality,
                PhoneNumber = d.PhoneNumber
            };
        }

        public async Task<DoctorDto> CreateDoctorAsync(CreateDoctorDto dto)
        {
            var doctor = new Doctor
            {
                Name = dto.Name,
                Speciality = dto.Speciality,
                PhoneNumber = dto.PhoneNumber
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return new DoctorDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Speciality = doctor.Speciality,
                PhoneNumber = doctor.PhoneNumber
            };
        }

        public async Task UpdateDoctorAsync(int id, UpdateDoctorDto dto)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                doctor.Name = dto.Name;
                doctor.Speciality = dto.Speciality;
                doctor.PhoneNumber = dto.PhoneNumber;

                _context.Doctors.Update(doctor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}