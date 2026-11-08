using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Application.Services;
using HospitalManagementSystem.Domain.Entities;
using HospitalManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _context.Patients.ToListAsync();
            return patients.Select(p => new PatientDto
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                Gender = p.Gender,
                PhoneNumber = p.PhoneNumber
            });
        }

        public async Task<PatientDto?> GetPatientByIdAsync(int id)
        {
            var p = await _context.Patients.FindAsync(id);
            if (p == null) return null;

            return new PatientDto
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                Gender = p.Gender,
                PhoneNumber = p.PhoneNumber
            };
        }

        public async Task<PatientDto> CreatePatientAsync(CreatePatientDto dto)
        {
            var patient = new Patient
            {
                Name = dto.Name,
                Age = dto.Age,
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Age = patient.Age,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber
            };
        }

        public async Task UpdatePatientAsync(int id, UpdatePatientDto dto)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                patient.Name = dto.Name;
                patient.Age = dto.Age;
                patient.Gender = dto.Gender;
                patient.PhoneNumber = dto.PhoneNumber;

                _context.Patients.Update(patient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}