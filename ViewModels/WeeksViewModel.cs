//to be written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutriWeekMAUI.DataStructures;
using System.Collections.ObjectModel;

namespace NutriWeekMAUI.ViewModels
{
    public partial class WeeksViewModel : ObservableObject
    {
        /// Constructor
        public WeeksViewModel()
        {
            Weeks = new ObservableCollection<string>();
            foreach (Week eachWeek in DataStorage.StoredWeeks)
            {
                //Only display future weeks on this screen, not past ones
                //Can't be asked to do date and time storage+comparision right now, it's irrelevant for the demo anyway
                //if(eachWeek.StartDate + 6 > currentdate)
                {
                    Weeks.Add(eachWeek.StartDate);
                }
            }

            Weeks.Add(" + Create New Week");
        }

        /// Collection of weeks
        [ObservableProperty]
        ObservableCollection<string> weeks;

        /// This is used to pass the selected week to the CurrentWeekPage
        [RelayCommand]
        async Task GoToWeek(string s)
        {
            for (int i = 0; i < DataStorage.StoredWeeks.Count; i++)
            {                
                if (DataStorage.StoredWeeks[i].StartDate == s)
                {
                    MauiProgram.CurrentWeekViewIndex = i;
                }
            }

            if(s == " + Create New Week")
            {
                DataStorage.StoredWeeks.Add(new Week("4/21"));
            }

            await Shell.Current.GoToAsync($"{nameof(CurrentWeekPage)}?Text={s}");
        }
    }
}
