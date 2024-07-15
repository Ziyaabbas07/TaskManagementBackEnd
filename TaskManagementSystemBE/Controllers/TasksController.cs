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
    public class TasksController(ITaskService Taskservice) : ControllerBase
    {
        private readonly ITaskService _Taskservice = Taskservice;
        // GET: api/<TasksController>
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                var data = _Taskservice.GetAllTasks();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTasksById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Tasks Id should greater than 0. ");
                }
                var data = _Taskservice.GetTasks(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTasksByUserId(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("User Id should greater than 0. ");
                }
                var data = _Taskservice.GetTasksByUserId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TasksRequest TasksRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                await _Taskservice.AddTasks(TasksRequest);
                return Ok("Tasks Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        } 
        [HttpPost]
        public async Task<IActionResult> ChangeTaskStatus(int id,int status)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                DataLayer.Models.TaskStatus changeStatus = (DataLayer.Models.TaskStatus)status;
                await _Taskservice.ChangeTaskStatus(id, changeStatus);
                return Ok("Task Status Changed Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTasks(int id, [FromBody] TasksRequest Tasks)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                await _Taskservice.UpdateTasks(id, Tasks);
                return Ok("Tasks Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Tasks Id should greater than 0. ");
                }
                await _Taskservice.TasksDelete(id);
                return Ok("Tasks Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
