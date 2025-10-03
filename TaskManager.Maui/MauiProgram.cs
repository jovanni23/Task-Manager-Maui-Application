using Microsoft.Extensions.Logging;
using TaskManager.Maui.Services;
using TaskManager.Maui.ViewModels;
using TaskManager.Maui.Views;

namespace TaskManager.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Services
            builder.Services.AddSingleton<TaskService>();
            builder.Services.AddSingleton<QuoteService>();

            // ViewModels
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<AddTaskViewModel>();
            builder.Services.AddTransient<EditTaskViewModel>();

            // Pages
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<AddTaskPage>();
            builder.Services.AddTransient<EditTaskPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
