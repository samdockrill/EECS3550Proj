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
                int day = DataStorage.StoredWeeks[DataStorage.StoredWeeks.Count - 1].day;
                int month = DataStorage.StoredWeeks[DataStorage.StoredWeeks.Count - 1].month;

                day += 7;
                if(day > 30)
                {
                    day -= 30;
                    month++;
                    if(month > 12)
                    {
                        month = 0;
                    }
                }

                Week newWeek = new Week(month, day);
                s = newWeek.StartDate;
                for (int i = 0; i < 7; i++)
                {
                    newWeek.Days.Add(new Day());
                }
                DataStorage.StoredWeeks.Add(newWeek);
                Weeks.Remove(" + Create New Week");
                Weeks.Add(s);
                Weeks.Add(" + Create New Week");
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(CurrentWeekPage)}?Text={s}");
        }
    }
}
