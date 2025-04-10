//written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutriWeekMAUI.DataStructures;
using System.Collections.ObjectModel;

namespace NutriWeekMAUI.ViewModels
{
    /// <summary>
    [QueryProperty("Text", "Text")]

    public partial class DayViewModel : ObservableObject
    {
        /// Constructor
        public DayViewModel()
        {
            Days = new ObservableCollection<string>();

            foreach (Food f in DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[MauiProgram.CurrentDayViewIndex].Foods)
            {
                Days.Add(f.Name);
            }

            if(Days.Count < 3)
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
            //DO NOTHING if the user clicks on the Nutrition Data box
            if(s.Contains("Nutrition Data"))
            {
                return;
            }

            if(s.Contains(" + Add a New Food"))
            {
                //Create a new food object
                Food newFood = new Food("New Food");
                MauiProgram.CurrentFood = newFood;
                DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[MauiProgram.CurrentDayViewIndex].Foods.Add(newFood);
            }
            else
            {
                //Loop over the 'Foods' list for the current day until it finds one whose name matches the name of the tapped button
                //Then set that as the MauiProgram.CurrentFood static reference
                for (int i = 0; i < DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[MauiProgram.CurrentDayViewIndex].Foods.Count; i++)
                {
                    if (DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[MauiProgram.CurrentDayViewIndex].Foods[i].Name == s)
                    {
                        MauiProgram.CurrentFood = DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[MauiProgram.CurrentDayViewIndex].Foods[i];
                    }
                }
            }

            await Shell.Current.GoToAsync(nameof(FoodPage));
        }

        /// This is used to go back to the weeks page
        [RelayCommand]
        async Task BackToWeeks()
        {
            await Shell.Current.GoToAsync(nameof(CurrentWeekPage));
        }
    }
}
