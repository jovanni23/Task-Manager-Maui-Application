using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TaskManager.Maui.Models;

namespace TaskManager.Maui.Services
{
    public class TaskService
    {
        private ISQLiteAsyncConnection _db;

        public async Task Init()
        {
            if (_db != null) return;
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "tasks.db");
            _db = new SQLiteAsyncConnection(dbPath);
            await _db.CreateTableAsync<TaskItem>();
        }

        public async Task<List<TaskItem>> GetTasksAsync()
        {
            await Init();
            return await _db.Table<TaskItem>().OrderByDescending(q=>q.Id).ToListAsync();
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            await Init();
            await _db.InsertAsync(task);
        }

        public async Task DeleteTaskAsync(TaskItem task)
        {
            await Init();
            await _db.DeleteAsync(task);
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return await _db.Table<TaskItem>().Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            if (task == null || task.Id == 0)
                return;

            await _db.UpdateAsync(task);
        }
    }
}
