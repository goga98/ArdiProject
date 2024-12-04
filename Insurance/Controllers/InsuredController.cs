using Insurance.Application.DTOs;
using Insurance.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuredController : ControllerBase
    {
        private readonly IInsuredService _insuredService;

        public InsuredController(IInsuredService insuredService, IPolicyService policyService)
        {
            _insuredService = insuredService;
        }

        [HttpGet("GetInsured")]
        public async Task<ActionResult<IEnumerable<InsuredDto>>> GetInsured()
        {
            var insureds = await _insuredService.GetAllAsync();
            return Ok(insureds);
        }

        [HttpGet("GetInsuredById")]
        public async Task<ActionResult<InsuredDto>> GetInsuredById(int id)
        {
            var insured = await _insuredService.GetByIdAsync(id);
            if (insured == null)
                return NotFound();
            return Ok(insured);
        }

        [HttpPost("AddInsured")]
        public async Task<ActionResult<InsuredDto>> AddInsured(InsuredCreateDto insuredDto)
        {
            var result = await _insuredService.CreateAsync(insuredDto);
            return CreatedAtAction("GetInsuredById", "Insured", new { id = result.Id }, result);
        }

        [HttpPut("UpdateInsured")]
        public async Task<IActionResult> UpdateInsured(int id, InsuredUpdateDto insuredDto)
        {
            if (id != insuredDto.Id)
                return BadRequest();

            try
            {
                await _insuredService.UpdateInsuredAsync(insuredDto);
                var updated = await _insuredService.GetByIdAsync(id);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "შეცდომა განახლებისას" });
            }
        }

        [HttpDelete("DeleteInsured")]
        public async Task<IActionResult> DeleteInsured(int id)
        {
            var result = await _insuredService.DeleteAsync(id);
            if (!result.Succeeded)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }


    }
}
