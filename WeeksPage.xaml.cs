namespace NutriWeekMAUI
{
    public partial class WeeksPage : ContentPage
    {
        public WeeksPage()
        {
            InitializeComponent();
        }

        private void Week1Btn_Clicked(object sender, EventArgs e)
        {
            Week1Btn.Text = "WEEK 1";
            Week1Btn.TextColor = Colors.White;
            Week1Btn.BackgroundColor = Colors.SeaGreen;

            Week2Btn.IsVisible = true;
        }

        private void Week2Btn_Clicked(object sender, EventArgs e)
        {
            Week2Btn.Text = "WEEK 2";
            Week2Btn.TextColor = Colors.White;
            Week2Btn.BackgroundColor = Colors.SeaGreen;

            Week3Btn.IsVisible = true;
        }

        private void Week3Btn_Clicked(object sender, EventArgs e)
        {
            Week3Btn.Text = "WEEK 3";
            Week3Btn.TextColor = Colors.White;
            Week3Btn.BackgroundColor = Colors.SeaGreen;

            Week4Btn.IsVisible = true;
        }

        private void Week4Btn_Clicked(object sender, EventArgs e)
        {
            Week4Btn.Text = "WEEK 4";
            Week4Btn.TextColor = Colors.White;
            Week4Btn.BackgroundColor = Colors.SeaGreen;

            Week5Btn.IsVisible = true;
        }

        private void Week5Btn_Clicked(object sender, EventArgs e)
        {
            Week5Btn.Text = "WEEK 5";
            Week5Btn.TextColor = Colors.White;
            Week5Btn.BackgroundColor = Colors.SeaGreen;
        }
    }
}

