using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly TaskService _taskService;
        private readonly QuoteService _quoteService;

        public ObservableCollection<TaskItem> Tasks { get; set; } = new();

        [ObservableProperty] 
        string motivationalQuote;

        [ObservableProperty]
        bool isRefreshing;

        public HomeViewModel(TaskService taskService, QuoteService quoteService)
        {
            Title = "Tasks";
            _taskService = taskService;
            _quoteService = quoteService;
        }

        [RelayCommand]
        public async Task LoadTasksAsync()
        {
            if(IsBusy) return;
            try
            {
                IsBusy = true;
                Tasks.Clear();
                var items = await _taskService.GetTasksAsync();
                foreach (var item in items)
                    Tasks.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get tasks list: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to retrieve task list", "Ok");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
            
        }

        [RelayCommand]
        public async Task FetchQuoteAsync()
        {
            MotivationalQuote = await _quoteService.GetRandomQuotes();
        }

        [RelayCommand]
        public async Task NavigateToAddTaskAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddTaskPage));
        }

        [RelayCommand]
        public async Task DeleteTask(TaskItem task)
        {
            if (task == null) return;

            await _taskService.DeleteTaskAsync(task);

            Tasks.Remove(task);
        }

        [RelayCommand]
        public async Task EditTaskAsync(TaskItem task)
        {
            if (task == null || task.Id == 0) return;

            var route = $"{nameof(EditTaskPage)}?taskId={task.Id}";

            await Shell.Current.GoToAsync(route);
        }
    }
}
