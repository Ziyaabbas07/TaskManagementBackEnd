using DataLayer.Models;
using ServiceLayer.DTOs.Requests;
using ServiceLayer.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface ITaskService
    {
        Task AddTasks(TasksRequest Tasks);
        IQueryable GetAllTasks();
        TasksResponse GetTasks(int id);
        List<TasksResponse> GetTasksByUserId(int id);
        Task UpdateTasks(int id, TasksRequest Tasks);
        Task ChangeTaskStatus(int id, DataLayer.Models.TaskStatus status);

        Task TasksDelete(int id);
    }
}
