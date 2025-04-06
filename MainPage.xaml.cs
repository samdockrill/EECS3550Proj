namespace NutriWeekMAUI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DisclaimerPage());
    }

    private void OnFoodClicked(object sender, EventArgs e)
    {
    }
}

