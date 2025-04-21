using Microsoft.Extensions.Logging;
using NutriWeekMAUI.DataStructures;
using NutriWeekMAUI.ViewModels;
using ZXing.Net.Maui.Controls;

namespace NutriWeekMAUI
{
    public static class MauiProgram
    {
        public static int CurrentWeekViewIndex = 0;
        public static int CurrentDayViewIndex = 0;
        public static Food CurrentFood = new Food("the intractable void (you should not be seeing this)");

        public static MauiApp CreateMauiApp()
        {
            DataStorage.LoadWeeks();
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBarcodeReader()
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

            builder.Services.AddTransient<FoodPage>();
            builder.Services.AddTransient<FoodViewModel>();

            builder.Services.AddTransient<TNTPage>();
            builder.Services.AddTransient<TNTViewModel>();

            builder.Services.AddTransient<MInputPage>();
            builder.Services.AddTransient<MInputViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
