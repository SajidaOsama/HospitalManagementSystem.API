using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAll()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorDto>> Create(CreateDoctorDto dto)
        {
            var createdDoctor = await _doctorService.CreateDoctorAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdDoctor.Id }, createdDoctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDoctorDto dto)
        {
            await _doctorService.UpdateDoctorAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }
    }
}