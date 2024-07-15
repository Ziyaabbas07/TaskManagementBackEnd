using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Requests;
using ServiceLayer.IServices;
using ServiceLayer.Services;

namespace TaskManagementSystemBE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest dto )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,ModelState);
                }
                var data =  _userService.SignUp(dto);
                return Ok("SignUp Successfully");
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest dto )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,ModelState);
                }
                var data =  _userService.Login(dto);
                return Ok(data);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var data = _userService.GetAllEmployees();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
