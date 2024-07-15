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
    public class TaskAttachmentsController(ITaskAttachmentService TaskAttachmentservice, IWebHostEnvironment hostingEnvironment) : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment = hostingEnvironment;

        private readonly ITaskAttachmentService _TaskAttachmentservice = TaskAttachmentservice;
        // GET: api/<TaskAttachmentsController>
        [HttpGet]
        public async Task<IActionResult> GetTaskAttachments()
        {
            try
            {
                var data = _TaskAttachmentservice.GetAllTaskAttachments();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<TaskAttachmentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskAttachmentsById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("TaskAttachments Id should greater than 0. ");
                }
                var data = _TaskAttachmentservice.GetTaskAttachments(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<TaskAttachmentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskAttachmentsByTaskId(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("TaskId should greater than 0. ");
                }
                var data = _TaskAttachmentservice.GetTaskAttachmentsByTaskId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<TaskAttachmentsController>
        [HttpPost]
        public async Task<IActionResult> AddTaskAttachment(IFormFile file,int taskId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded");
                }
                string filePath = ImageUpload(file, out filePath);
                string fileName = file.FileName;

                await _TaskAttachmentservice.AddTaskAttachments(taskId,filePath,fileName);
                return Ok("TaskAttachments Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private string ImageUpload(IFormFile file, out string filePath)
        {
            // Get the wwwroot folder path
            var wwwrootPath = _hostingEnvironment.WebRootPath;

            // Create the target directory if it doesn't exist
            var targetDirectory = Path.Combine(wwwrootPath, "uploads");
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            // Generate a unique filename (optional)
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            filePath = Path.Combine(targetDirectory, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return filePath;
        }

        // PUT api/<TaskAttachmentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAttachments(int id, int taskId, IFormFile file)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded");
                }
                string filePath = ImageUpload(file, out filePath);
                string fileName = file.FileName;
                await _TaskAttachmentservice.UpdateTaskAttachments(id, taskId,filePath,fileName);
                return Ok("TaskAttachments Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<TaskAttachmentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAttachments(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("TaskAttachments Id should greater than 0. ");
                }
                await _TaskAttachmentservice.TaskAttachmentsDelete(id);
                return Ok("TaskAttachments Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
