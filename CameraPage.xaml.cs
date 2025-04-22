using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using Microsoft.Maui.Controls;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace NutriWeekMAUI;

public partial class CameraPage : ContentPage
{
    public CameraPage()
    {
        InitializeComponent();
        cameraView.Options = new ZXing.Net.Maui.BarcodeReaderOptions()
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.Ean13,
            AutoRotate = true
        };
    }

    private async void BarcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        var first = e.Results.FirstOrDefault();

        if (first == null)
            return;

        cameraView.IsDetecting = false;

        string barcode = first.Value;
        string productName = await LookupProductName(barcode);
    }

    private async Task<string> LookupProductName(string barcode)
    {
        string url = $"https://world.openfoodfacts.org/api/v0/product/{barcode}.json";

        using var client = new HttpClient();
        try
        {
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return "Failed to fetch product info.";

            var content = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(content);

            if (data["status"]?.ToString() == "1")
            {
                string name = data["product"]?["product_name"]?.ToString();
                return string.IsNullOrWhiteSpace(name) ? "Unnamed product" : name;
            }
            else
            {
                return "Product not found.";
            }
        }
        catch
        {
            return "Error connecting to Open Food Facts.";
        }
    }
}