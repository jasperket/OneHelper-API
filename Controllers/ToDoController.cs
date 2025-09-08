using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OneHelper.Dto;
using OneHelper.Services.ToDoService;
using OneHelper.Models;

namespace OneHelper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        private readonly IMapper _mapper;
        private readonly ILogger<ToDoController> _logger;
        public ToDoController(IToDoService service, ILogger<ToDoController> logger, IMapper mapper)
        {
            _toDoService = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddToDo(ToDoRequest dto)
        {
            try
            {
                await _toDoService.AddToDoAsync(_mapper.Map<ToDo>(dto));
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDo(int id, ToDoRequest dto)
        {
            try
            {
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
                return Ok(_mapper.Map<List<ToDoResponse>>(await _toDoService.GetAllToDosAsync()));
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
                return Ok(await _toDoService.GetToDoByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
