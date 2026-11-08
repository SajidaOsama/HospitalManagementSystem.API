using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Domain.Entities;

namespace HospitalManagementSystem.Application.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto?> GetPatientByIdAsync(int id);
        Task<PatientDto> CreatePatientAsync(CreatePatientDto dto);
        Task UpdatePatientAsync(int id, UpdatePatientDto dto);
        Task DeletePatientAsync(int id);
    }
}