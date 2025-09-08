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
        private readonly IMapper _mapper;
        private readonly ILogger<ToDoController> _logger;
        private readonly IValidator<ToDoRequest> _validator;
        public ToDoController(IToDoService service, ILogger<ToDoController> logger, IMapper mapper, IValidator<ToDoRequest> validator)
        {
            _toDoService = service;
            _logger = logger;
            _mapper = mapper;
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
                    return BadRequest(validationResult.Errors);
                }
                await _toDoService.AddToDoAsync(_mapper.Map<ToDo>(dto));
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
                    return BadRequest(validationResult.Errors);
                }
                await _toDoService.UpdateToDoAsync(_mapper.Map<ToDo>(dto));
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
                return Ok(_mapper.Map<List<ToDoResponse>>(await _toDoService.GetAllToDosAsync()) ?? []);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await _toDoService.GetToDoByIdAsync(id);
                return Ok(_mapper.Map<ToDoResponse>(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
