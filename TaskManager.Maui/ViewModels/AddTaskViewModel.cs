using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManager.Maui.Models;
using TaskManager.Maui.Services;
using TaskManager.Maui.Views;

namespace TaskManager.Maui.ViewModels
{
    public partial class AddTaskViewModel : BaseViewModel
    {
        private readonly TaskService _taskService;

        [ObservableProperty] 
        string taskTitle;
        [ObservableProperty]
        DateTime dueDate;
        [ObservableProperty]
        bool isCompleted;

        public AddTaskViewModel(TaskService taskService)
        {
            _taskService = taskService;
        }

        [RelayCommand]
        public async Task SaveTaskAsync()
        {
            // validate task
            if (string.IsNullOrWhiteSpace(TaskTitle))
            {
                await Shell.Current.DisplayAlert("Validation Error", "Please add task title", "Ok");
                return;
            }

            if (DueDate.Date < DateTime.Today)
            {
                await Shell.Current.DisplayAlert("Validation Error", "Due date can't be past", "Ok");
                return;
            }
            var task = new TaskItem()
            {
                Title = TaskTitle,
                DueDate = DueDate,
                IsCompleted = IsCompleted
            };

            await _taskService.AddTaskAsync(task);
            //
            await Shell.Current.GoToAsync("..");
        }

    }
}
