using System.Threading.Tasks;

namespace NutriWeekMAUI;

public partial class DisclaimerPage : ContentPage
{
	public DisclaimerPage()
	{
		InitializeComponent();
	}

    private void DisclaimerBtn_Clicked(object sender, EventArgs e)
    {
		/*var existingWeekPage = Navigation.NavigationStack.OfType<WeeksPage>().FirstOrDefault();

        if (existingWeekPage != null)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(existingWeekPage);
        }
        else
        {
            await Navigation.PushAsync(new WeeksPage());
        }*/
        Navigation.PushAsync(new WeeksPage());
    }
}