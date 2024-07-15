using DataLayer.Models;
using ServiceLayer.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface ITeamService
    {
        Task AddTeam(TeamRequest team);
        IQueryable GetAllTeam();
        Team GetTeam(int id);
        Task UpdateTeam(int id,TeamRequest team);
        Task TeamDelete(int id);
    }
}
