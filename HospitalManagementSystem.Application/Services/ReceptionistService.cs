using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Domain.Entities;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Application.Services
{
    public class ReceptionistService : IReceptionistService
    {
        private readonly ApplicationDbContext _context;

        public ReceptionistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReceptionistDto>> GetAllReceptionistsAsync()
        {
            var receptionists = await _context.Receptionists.ToListAsync();
            return receptionists.Select(r => new ReceptionistDto
            {
                Id = r.Id,
                Name = r.Name,
                EmployeeCode = r.EmployeeCode,
                PhoneNumber = r.PhoneNumber
            });
        }

        public async Task<ReceptionistDto?> GetReceptionistByIdAsync(int id)
        {
            var r = await _context.Receptionists.FindAsync(id);
            if (r == null) return null;

            return new ReceptionistDto
            {
                Id = r.Id,
                Name = r.Name,
                EmployeeCode = r.EmployeeCode,
                PhoneNumber = r.PhoneNumber
            };
        }

        public async Task<ReceptionistDto> CreateReceptionistAsync(CreateReceptionistDto dto)
        {
            var receptionist = new Receptionist
            {
                Name = dto.Name,
                EmployeeCode = dto.EmployeeCode,
                PhoneNumber = dto.PhoneNumber
            };

            _context.Receptionists.Add(receptionist);
            await _context.SaveChangesAsync();

            return new ReceptionistDto
            {
                Id = receptionist.Id,
                Name = receptionist.Name,
                EmployeeCode = receptionist.EmployeeCode,
                PhoneNumber = receptionist.PhoneNumber
            };
        }

        public async Task UpdateReceptionistAsync(int id, UpdateReceptionistDto dto)
        {
            var receptionist = await _context.Receptionists.FindAsync(id);
            if (receptionist != null)
            {
                receptionist.Name = dto.Name;
                receptionist.EmployeeCode = dto.EmployeeCode;
                receptionist.PhoneNumber = dto.PhoneNumber;

                _context.Receptionists.Update(receptionist);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteReceptionistAsync(int id)
        {
            var receptionist = await _context.Receptionists.FindAsync(id);
            if (receptionist != null)
            {
                _context.Receptionists.Remove(receptionist);
                await _context.SaveChangesAsync();
            }
        }
    }
}