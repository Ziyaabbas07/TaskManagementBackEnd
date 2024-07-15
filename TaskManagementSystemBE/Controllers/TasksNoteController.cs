using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using ServiceLayer.DTOs.Requests;
using ServiceLayer.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagementSystemBE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TasksNoteController(ITasksNoteService TasksNoteervice) : ControllerBase
    {
        private readonly ITasksNoteService _TaskNoteService = TasksNoteervice;
        // GET: api/<TasksNoteController>
        [HttpGet]
        public async Task<IActionResult> GetTasksNote()
        {
            try
            {
                var data = _TaskNoteService.GetAllTasksNote();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<TasksNoteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTasksNoteById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("TasksNote Id should greater than 0. ");
                }
                var data = _TaskNoteService.GetTasksNote(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTasksNoteByTaskId(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("TasksNote Id should greater than 0. ");
                }
                var data = _TaskNoteService.GetTaskNotesByTaskId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<TasksNoteController>
        [HttpPost]
        public async Task<IActionResult> AddTaskNote([FromBody] TaskNotesRequest TasksNoteRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                await _TaskNoteService.AddTasksNote(TasksNoteRequest);
                return Ok("TasksNote Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<TasksNoteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTasksNote(int id, [FromBody] TaskNotesRequest TasksNote)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                await _TaskNoteService.UpdateTasksNote(id, TasksNote);
                return Ok("TasksNote Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<TasksNoteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasksNote(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("TasksNote Id should greater than 0. ");
                }
                await _TaskNoteService.TasksNoteDelete(id);
                return Ok("TasksNote Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
