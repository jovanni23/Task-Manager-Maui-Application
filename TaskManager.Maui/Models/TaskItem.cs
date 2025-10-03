using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Maui.Models
{
    public class TaskItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime DueDate { get; set; } = DateTime.Today;

        public bool IsCompleted { get; set; } = false;
    }
}
