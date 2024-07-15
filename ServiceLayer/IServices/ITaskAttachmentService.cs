using DataLayer.Models;
using ServiceLayer.DTOs.Requests;
using ServiceLayer.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.IServices
{
    public interface ITaskAttachmentService
    {
        Task AddTaskAttachments(int taskId,string filePath,string fileName);
        IQueryable GetAllTaskAttachments();
        TaskAttachmentResponse GetTaskAttachments(int id);
        List<TaskAttachmentResponse> GetTaskAttachmentsByTaskId(int id);
        Task UpdateTaskAttachments(int id, int taskId, string filePath, string fileName);
        Task TaskAttachmentsDelete(int id);
    }
}
