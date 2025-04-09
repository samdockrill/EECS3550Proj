//to be written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace NutriWeekMAUI.ViewModels
{
    public partial class WeeksViewModel : ObservableObject
    {
        /// Constructor
        public WeeksViewModel()
        {
            Weeks = new ObservableCollection<string>
            {
                "Week 1",
                "Week 2",
                "Week 3",
                "Week 4",
                "Week 5"
            };
        }

        /// Collection of weeks
        [ObservableProperty]
        ObservableCollection<string> weeks;

        /// This is used to pass the selected week to the CurrentWeekPage
        [RelayCommand]
        async Task GoToWeek(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(CurrentWeekPage)}?Text={s}");
        }
    }
}
