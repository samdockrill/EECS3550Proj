namespace NutriWeekMAUI
{
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class ManualBarcode
{
    static async Task Main(string[] args)
    {
        //enter barcode number 
        Console.WriteLine("Enter the barcode:");
        string barcode = Console.ReadLine();

        string foodName = await LookupFoodByBarcode(barcode);

        if (!string.IsNullOrEmpty(foodName))
            Console.WriteLine($"Food item: {foodName}");
        else
            Console.WriteLine("Food not found for this barcode.");
    }

    static async Task<string> LookupFoodByBarcode(string barcode)
    {
        using HttpClient client = new HttpClient();
        string url = $"https://world.openfoodfacts.org/api/v0/product/{barcode}.json";

        try
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            JObject data = JObject.Parse(json);

            if (data["status"].ToString() == "1")
            {
                string productName = data["product"]?["product_name"]?.ToString();
                return string.IsNullOrWhiteSpace(productName) ? "Unnamed product" : productName;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return null;
    }
}

}