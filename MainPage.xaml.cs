namespace NutriWeekMAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        int asdf = 1999;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void OnFoodClicked(object sender, EventArgs e)
        {
        }
    }
}
