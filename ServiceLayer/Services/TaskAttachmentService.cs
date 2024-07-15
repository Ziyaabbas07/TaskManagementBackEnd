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
    public class TaskAttachmentService(ApplicationDbContext context) : ITaskAttachmentService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task AddTaskAttachments(int taskId, string filePath, string fileName)
        {
            var team = new TaskAttachment
            {
                TaskId = taskId,
                FilePath = filePath,
                FileName = fileName
            };
            _context.Add(team);
            await _context.SaveChangesAsync();
        }

        public IQueryable GetAllTaskAttachments()
        {
            var data = _context.TaskAttachments.AsQueryable();
            return data;
        }

        public TaskAttachmentResponse GetTaskAttachments(int id)
        {
            var data = _context.TaskAttachments.Where(x => x.TaskAttachmentId == id).FirstOrDefault();
            TaskAttachmentResponse response = new();
            if (data != null)
            {
                response.TaskAttachmentId = data.TaskAttachmentId;
                response.FilePath = data.FilePath;  
                response.TaskId = data.TaskId;
            }
            return response;
        }

        public List<TaskAttachmentResponse> GetTaskAttachmentsByTaskId(int id)
        {
            var data = _context.TaskAttachments.Where(x => x.TaskId == id).ToList();
            List<TaskAttachmentResponse> taskAttachmentResponses = new();
            if (data != null)
            {
                foreach (var attachment in data)
                {
                    TaskAttachmentResponse response = new();
                    response.TaskAttachmentId = attachment.TaskAttachmentId;
                    response.FilePath = attachment.FilePath;
                    response.TaskId = attachment.TaskId;
                    response.FileName = attachment.FileName;
                    taskAttachmentResponses.Add(response);
                }
                
            }
            return taskAttachmentResponses;
        }

        public async Task TaskAttachmentsDelete(int id)
        {
            var data = await _context.TaskAttachments.Where(x => x.TaskAttachmentId == id).FirstOrDefaultAsync();
            _context.TaskAttachments.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAttachments(int id, int taskId, string filePath, string fileName)
        {
            var data = await _context.TaskAttachments.Where(x => x.TaskAttachmentId == id).FirstOrDefaultAsync();
            data.FilePath = filePath;
            data.TaskId = taskId;
            data.FileName = fileName;
            _context.TaskAttachments.Update(data);
            await _context.SaveChangesAsync();
        }
    }
}
