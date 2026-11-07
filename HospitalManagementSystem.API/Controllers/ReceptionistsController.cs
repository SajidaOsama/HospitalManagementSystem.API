using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistsController : ControllerBase
    {
        private readonly IReceptionistService _receptionistService;

        public ReceptionistsController(IReceptionistService receptionistService)
        {
            _receptionistService = receptionistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceptionistDto>>> GetAll()
        {
            var list = await _receptionistService.GetAllReceptionistsAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReceptionistDto>> GetById(int id)
        {
            var receptionist = await _receptionistService.GetReceptionistByIdAsync(id);
            if (receptionist == null) return NotFound();
            return Ok(receptionist);
        }

        [HttpPost]
        public async Task<ActionResult<ReceptionistDto>> Create(CreateReceptionistDto dto)
        {
            var created = await _receptionistService.CreateReceptionistAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateReceptionistDto dto)
        {
            await _receptionistService.UpdateReceptionistAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _receptionistService.DeleteReceptionistAsync(id);
            return NoContent();
        }
    }
}