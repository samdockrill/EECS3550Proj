//written by Edward Keiper

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NutriWeekMAUI.DataStructures;
using System.Collections.ObjectModel;

namespace NutriWeekMAUI.ViewModels
{
    /// <summary>
    [QueryProperty("Text", "Text")]

    public partial class FoodViewModel : ObservableObject
    {
        /// Constructor
        public FoodViewModel()
        {
            Inputs = new ObservableCollection<string>();

            if(MauiProgram.CurrentFood.Name == "New Food")
            {
                Inputs.Add("TapNType");
                //Days.Add("Scan Barcode");
                //Days.Add("Recommended options");
                Inputs.Add("Manual Input");
            }
            else
            {
                string nutrition = "Food Nutrition Data: \n";

                foreach (KeyValuePair<string, float> k in MauiProgram.CurrentFood.FoodNutrients)
                {
                    nutrition += k.Key + ": " + k.Value + "\n";
                }

                Inputs.Add(nutrition);
            }
        }

        /// Collection of days
        [ObservableProperty]
        ObservableCollection<string> inputs;

        /// Property to hold the selected week
        [ObservableProperty]
        string text;

        /// This is used to navigate to the desired input method
        [RelayCommand]
        async Task GoToInputs(string s)
        {
            //return;
            //DO NOTHING if the user clicks on the Nutrition Data box
            if (s.Contains("Nutrition Data"))
            {
            }

            if (s.Contains("TapNType"))
            {
                await Shell.Current.GoToAsync(nameof(TNTPage));
            }
            else if (s.Contains("Manual Input"))
            {
                await Shell.Current.GoToAsync(nameof(MInputPage));
            }
        }

        /// This is used to go back to the day page
        [RelayCommand]
        async Task BackToDay()
        {
            await Shell.Current.GoToAsync(nameof(DayPage));
        }
    }
}
