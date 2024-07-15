using DataLayer.ApplicationDbContext;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs.Requests;
using ServiceLayer.DTOs.Responses;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class TaskService(ApplicationDbContext context) : ITaskService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task AddTasks(TasksRequest Tasks)
        {
            var tasks = new Tasks
            {
                Title = Tasks.Title,
                AssignedTo = Tasks.AssignedTo,
                Description = Tasks.Description,
                DueDate = Tasks.DueDate,
                Status = Tasks.Status,
            };
            _context.Tasks.Add(tasks);
            await _context.SaveChangesAsync();
        }

        public IQueryable GetAllTasks()
        {
            var data = _context.Tasks.AsQueryable();
            return data;
        }

        public TasksResponse GetTasks(int id)
        {
            var task = _context.Tasks.Where(x => x.TaskId == id).FirstOrDefault();

            TasksResponse tasksResponse = new();
            if (task != null)
            {
                tasksResponse.TaskId = task.TaskId;
                tasksResponse.Description = task.Description;
                tasksResponse.Status = task.Status;
                tasksResponse.DueDate = task.DueDate;
                tasksResponse.AssignedTo = task.AssignedTo;
                tasksResponse.Title = task.Title;
            }
            return tasksResponse;
        }

        public List<TasksResponse> GetTasksByUserId(int id)
        {
            var data = _context.Tasks.Where(x => x.AssignedTo == id).ToList();
            List<TasksResponse> tasks = new();
            if (data != null)
            {
                foreach (var task in data)
                {
                    TasksResponse tasksResponse = new();
                    tasksResponse.TaskId = task.TaskId;
                    tasksResponse.Description = task.Description;
                    tasksResponse.Status = task.Status;
                    tasksResponse.DueDate = task.DueDate;
                    tasksResponse.AssignedTo = task.AssignedTo;
                    tasksResponse.Title = task.Title;
                    tasks.Add(tasksResponse);
                }
            }
            return tasks;
        }

        public async Task TasksDelete(int id)
        {
            var data = await _context.Tasks.Where(x => x.TaskId == id).FirstOrDefaultAsync();
            _context.Tasks.Remove(data);
            await _context.SaveChangesAsync();
        }
        public async Task ChangeTaskStatus(int id,DataLayer.Models.TaskStatus status)
        {
            var data = await _context.Tasks.Where(x => x.TaskId == id).FirstOrDefaultAsync();
            data.Status = status;
            _context.Tasks.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTasks(int id, TasksRequest Tasks)
        {
            var data = await _context.Tasks.Where(x => x.TaskId == id).FirstOrDefaultAsync();
            data.Title = Tasks.Title;
            data.AssignedTo = Tasks.AssignedTo;
            data.Description = Tasks.Description;
            data.Status = Tasks.Status;
            data.DueDate = Tasks.DueDate;
            _context.Tasks.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}
