using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneHelper.Dto;
using OneHelper.Models;
using OneHelper.Services.SleepLogService;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace OneHelper.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SleepLogController(ISleepLogService service, ILogger<SleepLogController> logger, 
        IValidator<SleepRequest> validator) : ControllerBase 
    {
        private readonly ISleepLogService _sleepService = service;
        private readonly ILogger<SleepLogController> _logger = logger;
        private readonly IValidator<SleepRequest> _validator = validator;

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllSleepLogs()
        {
            try
            {
                var claimId = await Task.Run(() => User.FindFirstValue(ClaimTypes.NameIdentifier));
                return Ok(await _sleepService.GetAllSleepLogAsync(Convert.ToInt32(claimId ?? throw new Exception("Claim Id not found"))));
            }
            catch ( Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSleepById(int id)
        {
            try
            {
                return Ok(await _sleepService.GetSleepLogByIdAsync(id));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteSleepLog(int id)
        {
            try
            {
                await _sleepService.DeleteSleepLogAsync(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSleepLog(int id, SleepRequest dto)
        {
            try
            {
                var validation = await _validator.ValidateAsync(dto);
                if (!validation.IsValid) return BadRequest(validation.Errors);
                await _sleepService.UpdateSleepLogAsync(id, dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddSleepLog(SleepRequest dto)
        {
            try
            {
                var userId = await Task.Run(() => User.FindFirstValue(ClaimTypes.NameIdentifier));
                var validation = await _validator.ValidateAsync(dto);
                if (!validation.IsValid || userId is null) return BadRequest(validation.Errors);
                await _sleepService.AddSleepLogAsync(dto, Convert.ToInt32(userId));
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}
