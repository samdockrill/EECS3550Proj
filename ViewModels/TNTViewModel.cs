//written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutriWeekMAUI.DataStructures;
using System.Collections.ObjectModel;

namespace NutriWeekMAUI.ViewModels
{
    /// <summary>
    [QueryProperty("Text", "Text")]

    public partial class TNTViewModel : ObservableObject
    {
        /// Constructor
        public TNTViewModel()
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
