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

            Days = new ObservableCollection<string>();            
                
            for(int i = 0; i < 7; i++)
            {
                string s = DayFromIndex(i);

                for (int j = 0; j < DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[i].Foods.Count; j++)
                {
                    if (j == 0)
                    {
                        s += ":";
                    }
                    s += "\n -" + DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[i].Foods[j].Name;
                }

                Days.Add(s);
            }
        }

        /// This is used to convert the index of the day to the name of the day
        string DayFromIndex(int i)
        {
            if(i == 0)
            {
                return "Monday";
            }
            if (i == 1)
            {
                return "Tuesday";
            }
            if (i == 2)
            {
                return "Wednesday";
            }
            if (i == 3)
            {
                return "Thursday";
            }
            if (i == 4)
            {
                return "Friday";
            }
            if (i == 5)
            {
                return "Saturday";
            }
            if (i == 6)
            {
                return "Monday";
            }

            return "Sunday";
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
            if(s.Contains("Monday"))
            {
                MauiProgram.CurrentDayViewIndex = 0;
            }
            if (s.Contains("Tuesday"))
            {
                MauiProgram.CurrentDayViewIndex = 1;
            }
            if (s.Contains("Wednesday"))
            {
                MauiProgram.CurrentDayViewIndex = 2;
            }
            if (s.Contains("Thursday"))
            {
                MauiProgram.CurrentDayViewIndex = 3;
            }
            if (s.Contains("Friday"))
            {
                MauiProgram.CurrentDayViewIndex = 4;
            }
            if (s.Contains("Saturday"))
            {
                MauiProgram.CurrentDayViewIndex = 5;
            }
            if (s.Contains("Sunday"))
            {
                MauiProgram.CurrentDayViewIndex = 6;
            }

            // Get the day name from the index
            s = DayFromIndex(MauiProgram.CurrentDayViewIndex);

            // Pass the day name to the DayPage and navigate to it
            await Shell.Current.GoToAsync($"{nameof(DayPage)}?Text={s}");
        }

        /// This is used to go back to the weeks page
        [RelayCommand]
        async Task BackToWeeks()
        {
            await Shell.Current.GoToAsync(nameof(WeeksPage));
        }
    }
}
