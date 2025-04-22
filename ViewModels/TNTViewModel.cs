//written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutriWeekMAUI.DataStructures;
using NutriWeekMAUI.InputSystems;
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
            Foods = new ObservableCollection<string>();
            GetSearchResults();
        }

        /// Collection of days
        [ObservableProperty]
        ObservableCollection<string> foods;

        /// Property to hold the selected week
        [ObservableProperty]
        string text;

        /// <summary>
        /// This is used to retrieve the search results from the TapNType method
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [RelayCommand]
        async Task GetSearchResults()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return;
            }

            //Get the search results from the TapNType method
            Foods = TapnType.GetAutoCompleteList(Text);
        }

        List<Food> CachedFoodResults = new List<Food>();

        /// This is used to pass the desired food item to the DayPage
        [RelayCommand]
        async Task AddToDay(string s)
        {
            DataStorage.StoredWeeks[MauiProgram.CurrentWeekViewIndex].Days[MauiProgram.CurrentDayViewIndex].Foods.Add(DataStorage.NameLookup(s));
            await Shell.Current.GoToAsync(nameof(DayPage));
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
