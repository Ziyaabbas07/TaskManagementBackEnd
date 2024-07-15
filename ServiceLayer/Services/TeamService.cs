using DataLayer.ApplicationDbContext;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs.Requests;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class TeamService(ApplicationDbContext context) : ITeamService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task AddTeam(TeamRequest teamRequest)
        {
            var team = new Team
            {
                TeamName = teamRequest.TeamName
            };
            _context.Add(team);
            await _context.SaveChangesAsync();
        }

        public IQueryable GetAllTeam()
        {
            var data = _context.Teams.AsQueryable();
            return data;
        }

        public  Team GetTeam(int id)
        {
            var data = _context.Teams.Where(x=>x.TeamId == id).FirstOrDefault();
            return data;
        }

        public async Task TeamDelete(int id)
        {
            var data = await _context.Teams.Where(x => x.TeamId == id).FirstOrDefaultAsync();
            _context.Teams.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeam(int id,TeamRequest teamRequest)
        {
            var data = await _context.Teams.Where(x => x.TeamId == id).FirstOrDefaultAsync();
            data.TeamName = teamRequest.TeamName;
            _context.Teams.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}
