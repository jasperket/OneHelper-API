using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneHelper.Dto;
using OneHelper.Services.ToDoService;
using OneHelper.Models;
using FluentValidation;

namespace OneHelper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        private readonly ILogger<ToDoController> _logger;
        private readonly IValidator<ToDoRequest> _validator;
        public ToDoController(IToDoService service, ILogger<ToDoController> logger, IMapper mapper, IValidator<ToDoRequest> validator)
        {
            _toDoService = service;
            _logger = logger;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> AddToDo([FromBody] ToDoRequest dto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(dto);
                if (!validationResult.IsValid)
                {
                    _logger.LogInformation("Dto is invalid..... Adding operation cannot proceed");
                    return BadRequest(validationResult.Errors);
                }
                await _toDoService.AddToDoAsync(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDo(int id, [FromBody] ToDoRequest dto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(dto);
                if ( !validationResult.IsValid )
                {
                    _logger.LogInformation("Dto is invalid..... Updating operation cannot proceed");
                    return BadRequest(validationResult.Errors);
                }
                await _toDoService.UpdateToDoAsync(id, dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            try
            {
                await _toDoService.DeleteToDoAsync(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _toDoService.GetAllToDosAsync() ?? []);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await _toDoService.GetToDoByIdAsync(id);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
