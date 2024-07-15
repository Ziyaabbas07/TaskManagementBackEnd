using DataLayer.ApplicationDbContext;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs.Requests;
using ServiceLayer.DTOs.Responses;
using ServiceLayer.IServices;

namespace ServiceLayer.Services
{
    public class TasksNoteService(ApplicationDbContext context) : ITasksNoteService
    {
        private readonly ApplicationDbContext _context = context;
        public async Task AddTasksNote(TaskNotesRequest TasksNote)
        {
            var team = new TaskNote
            {
                TaskId = TasksNote.TaskId,
                Note = TasksNote.Note,
            };
            _context.Add(team);
            await _context.SaveChangesAsync();
        }

        public IQueryable GetAllTasksNote()
        {
            var data = _context.TaskNotes.AsQueryable();
            return data;
        }

        public TaskNoteResponse GetTasksNote(int id)
        {
            var data = _context.TaskNotes.Where(x => x.TaskNoteId == id).FirstOrDefault();
            TaskNoteResponse taskNoteResponse = new TaskNoteResponse();
            if (data == null)
            {
                taskNoteResponse.TaskId = data.TaskId;
                taskNoteResponse.Note = data.Note;
                taskNoteResponse.TaskNoteId = data.TaskNoteId;
            }
            return taskNoteResponse;
        }

        public List<TaskNoteResponse> GetTaskNotesByTaskId(int id)
        {
            var data =  _context.TaskNotes.Where(x => x.TaskId == id).ToList();
            List<TaskNoteResponse> result = new List<TaskNoteResponse>();
            if (data.Count > 0) 
            {
                foreach (var task in data)
                {
                    TaskNoteResponse taskNoteResponse = new TaskNoteResponse();
                    taskNoteResponse.TaskId = task.TaskId;
                    taskNoteResponse.Note = task.Note;
                    taskNoteResponse.TaskNoteId = task.TaskNoteId;
                    result.Add(taskNoteResponse);
                }
            }
            return result;
        }

        public async Task TasksNoteDelete(int id)
        {
            var data = await _context.TaskNotes.Where(x => x.TaskNoteId == id).FirstOrDefaultAsync();
            if (data != null)
            {
                _context.TaskNotes.Remove(data);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task UpdateTasksNote(int id, TaskNotesRequest TasksNote)
        {
            var data = await _context.TaskNotes.Where(x => x.TaskNoteId == id).FirstOrDefaultAsync();
            if (data != null) 
            {
                data.Note = TasksNote.Note;
                _context.TaskNotes.Update(data);
                await _context.SaveChangesAsync();
            }            
        }
    }
}
