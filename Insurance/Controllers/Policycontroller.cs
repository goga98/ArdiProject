using Insurance.Application.DTOs;
using Insurance.Application.Services;
using Insurance.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Policycontroller : Controller
    {

        private readonly IPolicyService _policyService;
        public Policycontroller(IPolicyService policyService)
        {
            _policyService = policyService;
        }
        [HttpGet("GetPolicy")]
        public async Task<ActionResult<IEnumerable<PolicyDto>>> GetPolicy()
        {
            var policyResult = await _policyService.GetAllAsync();
            return Ok(policyResult);
        }

        [HttpGet("GetPolicyById")]
        public async Task<ActionResult<PolicyDto>> GetPolicyById(int id)
        {
            var policyResult = await _policyService.GetByIdAsync(id);
            if (policyResult == null)
                return NotFound();
            return Ok(policyResult);
        }
        [HttpPost("AddPolicy")]
        public async Task<ActionResult<PolicyDto>> AddPolicy(PolicyCreateDto policyDto)
        {
            var result = await _policyService.CreateAsync(policyDto);
            return CreatedAtAction("GetPolicyById", "Policy", new { id = result.Id }, result);
        }
        [HttpPut("UpdatePolicy")]
        public async Task<IActionResult> UpdateInsured(int id, PolicyUpdateDto policyDto)
        {
            try
            {
                await _policyService.UpdatePolicy(policyDto);
                var updated = await _policyService.GetByIdAsync(id);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "შეცდომა განახლებისას" });
            }
        }
        [HttpDelete("DeletePolicy")]
        public async Task<IActionResult> DeleteInsured(int id)
        {
            await _policyService.DeleteAsync(id);
            return NoContent();
        }
        
    }
}
