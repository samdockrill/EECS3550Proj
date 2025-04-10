//written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutriWeekMAUI.DataStructures;
using System.Collections.ObjectModel;

namespace NutriWeekMAUI.ViewModels
{
    /// <summary>
    [QueryProperty("Text", "Text")]

    public partial class FoodViewModel : ObservableObject
    {
        /// Constructor
        public FoodViewModel()
        {
            Days = new ObservableCollection<string>();

            foreach (Food f in DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[MauiProgram.CurrentDayViewIndex].Foods)
            {
                Days.Add(f.Name);
            }

            if (Days.Count < 3)
            {
                Days.Add(" + Add a New Food");
            }

            string nutrition = "Full Daily Nutrition Data: \n" +
                "Placeholder Demo: Actual Graph Coming Soon!\n";

            foreach (KeyValuePair<string, float> k in DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[MauiProgram.CurrentDayViewIndex].DailyValues)
            {
                nutrition += k.Key + ": " + k.Value + "\n";
            }

            Days.Add(nutrition);
        }

        /// Collection of days
        [ObservableProperty]
        ObservableCollection<string> days;

        /// Property to hold the selected week
        [ObservableProperty]
        string text;

        /// This is used to pass the selected day to the DayPage
        [RelayCommand]
        async Task GoToDay(string s)
        {

        }

        /// This is used to go back to the weeks page
        [RelayCommand]
        async Task BackToWeeks()
        {
            await Shell.Current.GoToAsync(nameof(DayPage));
        }
    }
}
