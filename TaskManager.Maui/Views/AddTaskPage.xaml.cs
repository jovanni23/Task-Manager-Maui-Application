using Microsoft.VisualBasic;
using TaskManager.Maui.ViewModels;

namespace TaskManager.Maui.Views;

public partial class AddTaskPage : ContentPage
{
	public AddTaskPage(AddTaskViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;

        vm.DueDate = DateTime.Today;
    }
}