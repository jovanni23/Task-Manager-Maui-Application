using TaskManager.Maui.Views;

namespace TaskManager.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddTaskPage), typeof(AddTaskPage));
            Routing.RegisterRoute(nameof(EditTaskPage), typeof(EditTaskPage));
        }
    }
}
