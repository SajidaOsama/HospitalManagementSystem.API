using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagementSystem.Application.DTOs.Receptionist;

namespace HospitalManagementSystem.Application.Services.Receptionist
{
    public interface IReceptionistService
    {
        Task<IEnumerable<ReceptionistDto>> GetAllReceptionistsAsync();
        Task<ReceptionistDto?> GetReceptionistByIdAsync(int id);
        Task<ReceptionistDto> CreateReceptionistAsync(CreateReceptionistDto dto);
        Task UpdateReceptionistAsync(int id, UpdateReceptionistDto dto);
        Task DeleteReceptionistAsync(int id);
    }
}