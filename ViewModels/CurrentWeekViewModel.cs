//written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace NutriWeekMAUI.ViewModels
{
    /// <summary>
    [QueryProperty("Text", "Text")]

    public partial class CurrentWeekViewModel : ObservableObject
    {
        /// Constructor
        public CurrentWeekViewModel()
        {
            Days = new ObservableCollection<string>
            {
                "Monday\nTesttsts",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
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
            if(s == "Monday")
            {
                MauiProgram.CurrentDayViewIndex = 0;
            }
            if (s == "Tuesday")
            {
                MauiProgram.CurrentDayViewIndex = 1;
            }
            if (s == "Wednesday")
            {
                MauiProgram.CurrentDayViewIndex = 2;
            }
            if (s == "Thursday")
            {
                MauiProgram.CurrentDayViewIndex = 3;
            }
            if (s == "Friday")
            {
                MauiProgram.CurrentDayViewIndex = 4;
            }
            if (s == "Saturday")
            {
                MauiProgram.CurrentDayViewIndex = 5;
            }
            if (s == "Sunday")
            {
                MauiProgram.CurrentDayViewIndex = 6;
            }

            await Shell.Current.GoToAsync($"{nameof(DayPage)}?Text={s}");
        }

        /// This is used to go back to the weeks page
        [RelayCommand]
        async Task BackToWeeks()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
