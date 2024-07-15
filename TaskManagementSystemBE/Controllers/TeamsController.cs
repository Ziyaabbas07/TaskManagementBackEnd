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
    public class TeamsController(ITeamService teamService) : ControllerBase
    {
        private readonly ITeamService _teamService = teamService;
        // GET: api/<TeamsController>
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            try
            {
                var data = _teamService.GetAllTeam();
                return Ok(data);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            try
            {
                if (id == 0) 
                {
                    return BadRequest("Team Id should greater than 0. ");
                }
                var data = _teamService.GetTeam(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<TeamsController>
        [HttpPost]
        public async Task<IActionResult> AddTeam([FromBody] TeamRequest teamRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                await _teamService.AddTeam(teamRequest);
                return Ok("Team Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] TeamRequest team)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                await _teamService.UpdateTeam(id,team);
                return Ok("Team Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Team Id should greater than 0. ");
                }
                await _teamService.TeamDelete(id);
                return Ok("Team Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
