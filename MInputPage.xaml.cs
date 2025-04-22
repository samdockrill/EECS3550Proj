//written by Edward Keiper
using NutriWeekMAUI.ViewModels;

namespace NutriWeekMAUI;

public partial class MInputPage : ContentPage
{
    MInputViewModel model;
    public MInputPage(MInputViewModel vm)
    {
        InitializeComponent();
        model = vm;
        BindingContext = vm;
    }


    public void OnEntryTextChanged1(object sender, TextChangedEventArgs e)
    {
        model.newFood.Name = e.NewTextValue;
    }
    public void OnEntryTextChanged2(object sender, TextChangedEventArgs e)
    {
        string key = "Fat";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged3(object sender, TextChangedEventArgs e)
    {
        string key = "Saturated-Fat";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged4(object sender, TextChangedEventArgs e)
    {
        string key = "Trans-Fat";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged5(object sender, TextChangedEventArgs e)
    {
        string key = "Cholesterol";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged6(object sender, TextChangedEventArgs e)
    {
        string key = "Carbohydrates";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged7(object sender, TextChangedEventArgs e)
    {
        string key = "Sugars";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged8(object sender, TextChangedEventArgs e)
    {
        string key = "Fiber";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged9(object sender, TextChangedEventArgs e)
    {
        string key = "Proteins";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged10(object sender, TextChangedEventArgs e)
    {
        string key = "Sodium";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged11(object sender, TextChangedEventArgs e)
    {
        string key = "Vitamin-A";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged12(object sender, TextChangedEventArgs e)
    {
        string key = "Vitamin-E";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged13(object sender, TextChangedEventArgs e)
    {
        string key = "Vitamin-C";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged14(object sender, TextChangedEventArgs e)
    {
        string key = "Potassium";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged15(object sender, TextChangedEventArgs e)
    {
        string key = "Calcium";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged16(object sender, TextChangedEventArgs e)
    {
        string key = "Phosphorous";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged17(object sender, TextChangedEventArgs e)
    {
        string key = "Iron";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged18(object sender, TextChangedEventArgs e)
    {
        string key = "Magnesium";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
    public void OnEntryTextChanged19(object sender, TextChangedEventArgs e)
    {
        string key = "Zinc";
        float val = 0;
        if (float.TryParse(e.NewTextValue, out val))
        {
            if (!model.newFood.FoodNutrients.ContainsKey(key))
            {
                model.newFood.FoodNutrients.Add(key, val);
            }
            else
            {
                model.newFood.FoodNutrients[key] = val;
            }
        }
    }
}