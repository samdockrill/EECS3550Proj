using Microsoft.Extensions.Logging;
using NutriWeekMAUI.ViewModels;

namespace NutriWeekMAUI
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

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<DisclaimerPage>();
            builder.Services.AddSingleton<DisclaimerViewModel>();

            builder.Services.AddSingleton<WeeksPage>();
            builder.Services.AddSingleton<WeeksViewModel>();

            builder.Services.AddTransient<CurrentWeekPage>();
            builder.Services.AddTransient<CurrentWeekViewModel>();

            builder.Services.AddTransient<DayPage>();
            builder.Services.AddTransient<DayViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
