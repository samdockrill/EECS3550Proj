namespace NutriWeekMAUI;

public partial class DisclaimerPage : ContentPage
{
	public DisclaimerPage()
	{
		InitializeComponent();
	}

    private void DisclaimerBtn_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new WeeksPage());
    }
}