namespace NutriWeekMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(DisclaimerPage), typeof(DisclaimerPage));
            Routing.RegisterRoute(nameof(WeeksPage), typeof(WeeksPage));
            Routing.RegisterRoute(nameof(CurrentWeekPage), typeof(CurrentWeekPage));
            Routing.RegisterRoute(nameof(DayPage), typeof(DayPage));
            Routing.RegisterRoute(nameof(CameraPage), typeof(CameraPage));
            Routing.RegisterRoute(nameof(CameraConfirmPage), typeof(CameraConfirmPage));
            Routing.RegisterRoute(nameof(ManualInputPage), typeof(ManualInputPage));
            Routing.RegisterRoute(nameof(FoodPage), typeof(FoodPage));
            Routing.RegisterRoute(nameof(RecommendedPage), typeof(RecommendedPage));
        }
    }
}
