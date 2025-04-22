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

        /// This is used to register all of the maunally entered food data and add it to the current day
        [RelayCommand]
        async Task EnterManualData()
        {
            await Shell.Current.GoToAsync(nameof(FoodPage));
        }

        /// This is used to go back to the day page
        [RelayCommand]
        async Task BackToDay()
        {
            //When going back, remove the 'New Food' empty food that was created
            DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[MauiProgram.CurrentDayViewIndex].Foods.RemoveAll((Food f) => { return f.Name == "New Food"; });
            await Shell.Current.GoToAsync(nameof(DayPage));
        }
    }
}
