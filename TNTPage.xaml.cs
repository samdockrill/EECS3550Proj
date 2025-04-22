//written by Edward Keiper
using NutriWeekMAUI.InputSystems;
using NutriWeekMAUI.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace NutriWeekMAUI;

public partial class TNTPage : ContentPage
{
    TNTViewModel model;
    public TNTPage(TNTViewModel vm)
    {
        InitializeComponent();
        model = vm;
        BindingContext = vm;
    }

    public void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if(e.NewTextValue == null || e.NewTextValue == "")
        {
            model.Foods = new System.Collections.ObjectModel.ObservableCollection<string>();
        }
        else
        {
            model.Foods = TapnType.GetAutoCompleteList(e.NewTextValue);
        }
    }
}