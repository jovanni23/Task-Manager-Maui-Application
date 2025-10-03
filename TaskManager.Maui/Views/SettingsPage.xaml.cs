namespace TaskManager.Maui.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();

        switch (Application.Current.UserAppTheme)
        {
            case AppTheme.Light:
                ThemePicker.SelectedIndex = 1;
                break;
            case AppTheme.Dark:
                ThemePicker.SelectedIndex = 2;
                break;
            default:
                ThemePicker.SelectedIndex = 0;
                break;
        }
	}

    private void ThemePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var app = Application.Current as App;
        switch (ThemePicker.SelectedIndex)
        {
            case 0:
                var systemTheme = Application.Current.PlatformAppTheme;
                app?.SetTheme(systemTheme);
                break;
            case 1:

                app?.SetTheme(AppTheme.Light);
                break;
            case 2:
                app?.SetTheme(AppTheme.Dark);
                break;
        }
        {
            
        }
    }
}