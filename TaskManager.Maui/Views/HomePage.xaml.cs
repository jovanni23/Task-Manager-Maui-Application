using TaskManager.Maui.ViewModels;

namespace TaskManager.Maui.Views;

public partial class HomePage : ContentPage
{
	private readonly HomeViewModel _viewModel;
	public HomePage(HomeViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
		_viewModel = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_viewModel == null) return;

        try
        {
            await _viewModel.FetchQuoteAsync();

        }
        catch (Exception ex)
        {
            // log it instead of crashing
            System.Diagnostics.Debug.WriteLine($"Error fetching quote: {ex.Message}");
        }

        try
        {
            await _viewModel.LoadTasksAsync();

        }
        catch (Exception ex)
        {
            // log it instead of crashing
            System.Diagnostics.Debug.WriteLine($"Error fetching tasks: {ex.Message}");
        }


    }
}