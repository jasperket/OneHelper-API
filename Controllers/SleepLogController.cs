using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OneHelper.Dto;
using OneHelper.Models;
using OneHelper.Services.SleepLogService;

namespace OneHelper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SleepLogController(ISleepLogService service, ILogger<SleepLogController> logger, 
        IValidator<SleepRequest> validator) : ControllerBase 
    {
        private readonly ISleepLogService _sleepService = service;
        private readonly ILogger<SleepLogController> _logger = logger;
        private readonly IValidator<SleepRequest> _validator = validator;

        [HttpGet]
        public async Task<IActionResult> GetAllSleepLogs()
        {
            try
            {
                return Ok(await _sleepService.GetAllSleepLogAsync());
            }
            catch ( Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }

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

        [HttpPost]
        public async Task<IActionResult> AddSleepLog(SleepRequest dto)
        {
            try
            {
                var validation = await _validator.ValidateAsync(dto);
                if (!validation.IsValid) return BadRequest(validation.Errors);
                await _sleepService.AddSleepLogAsync(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        
    }
}
