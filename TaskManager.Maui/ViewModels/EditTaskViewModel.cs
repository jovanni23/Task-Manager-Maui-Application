using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManager.Maui.Models;
using TaskManager.Maui.Services;

namespace TaskManager.Maui.ViewModels
{
    [QueryProperty(nameof(TaskId), "taskId")]
    public partial class EditTaskViewModel : ObservableObject
    {
        private readonly TaskService _taskService;

        public EditTaskViewModel(TaskService taskService)
        {
            _taskService = taskService;
        }

        [ObservableProperty] 
        int taskId;

        [ObservableProperty]
        private TaskItem task;

        partial void OnTaskIdChanged(int value)
        {
            LoadTaskAsync(value);
        }

        private async void LoadTaskAsync(int id)
        {
            Task = await _taskService.GetTaskByIdAsync(id);
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            if (Task == null) return;

            await _taskService.UpdateTaskAsync(Task);

            // Go back to previous page
            await Shell.Current.GoToAsync("..");
        }
    }
}
