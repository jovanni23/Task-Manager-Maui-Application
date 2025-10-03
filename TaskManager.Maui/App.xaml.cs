namespace TaskManager.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // detect system teheme
            SetTheme(Application.Current.RequestedTheme);
            
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        public void SetTheme(AppTheme theme)
        {
            if (theme == AppTheme.Dark)
            {
                Resources.MergedDictionaries.Clear();
                Resources.MergedDictionaries.Add(Resources["DarkTheme"] as ResourceDictionary);
            }

            else
            {
                Resources.MergedDictionaries.Clear();
                Resources.MergedDictionaries.Add(Resources["LightTheme"] as ResourceDictionary);
            }
        }
    }
}