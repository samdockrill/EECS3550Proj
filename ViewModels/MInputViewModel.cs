//written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutriWeekMAUI.DataStructures;
using System.Collections.ObjectModel;

namespace NutriWeekMAUI.ViewModels
{
    /// <summary>
    [QueryProperty("Text", "Text")]

    public partial class MInputViewModel : ObservableObject
    {
        /// Constructor
        public MInputViewModel()
        {
            Days = new ObservableCollection<string>();

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
            if (s.Contains("Nutrition Data"))
            {
                return;
            }

            if (s.Contains("TapNType"))
            {
                await Shell.Current.GoToAsync(nameof(FoodPage));
            }
            else if (s.Contains("Manual Input"))
            {
                await Shell.Current.GoToAsync(nameof(FoodPage));
            }
        }

        /// This is used to go back to the weeks page
        [RelayCommand]
        async Task BackToWeeks()
        {
            //When going back, remove the 'New Food' empty food that was created
            DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[MauiProgram.CurrentDayViewIndex].Foods.RemoveAll((Food f) => { return f.Name == "New Food"; });
            await Shell.Current.GoToAsync(nameof(DayPage));
        }
    }
}
