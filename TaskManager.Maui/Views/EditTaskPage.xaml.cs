using TaskManager.Maui.ViewModels;

namespace TaskManager.Maui.Views;

public partial class EditTaskPage : ContentPage
{
	public EditTaskPage(EditTaskViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}