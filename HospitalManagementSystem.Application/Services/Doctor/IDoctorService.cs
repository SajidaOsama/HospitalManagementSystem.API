using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagementSystem.Application.DTOs.Doctor;

namespace HospitalManagementSystem.Application.Services.Doctor
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<DoctorDto?> GetDoctorByIdAsync(int id);
        Task<DoctorDto> CreateDoctorAsync(CreateDoctorDto dto);
        Task UpdateDoctorAsync(int id, UpdateDoctorDto dto);
        Task DeleteDoctorAsync(int id);
    }
}