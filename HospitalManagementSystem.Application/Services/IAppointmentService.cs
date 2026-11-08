using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagementSystem.Application.DTOs;

namespace HospitalManagementSystem.Application.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        Task<AppointmentDto?> GetAppointmentByIdAsync(Guid id);
        Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto dto);
        Task UpdateAppointmentAsync(Guid id, UpdateAppointmentDto dto);
        Task DeleteAppointmentAsync(Guid id);
    }
}