using DataLayer.Models;
using ServiceLayer.DTOs.Requests;
using ServiceLayer.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.IServices
{
    public interface ITasksNoteService
    {
        Task AddTasksNote(TaskNotesRequest TasksNote);
        IQueryable GetAllTasksNote();
        TaskNoteResponse GetTasksNote(int id);
        List<TaskNoteResponse> GetTaskNotesByTaskId(int id);
        Task UpdateTasksNote(int id, TaskNotesRequest TasksNote);
        Task TasksNoteDelete(int id);
    }
}
