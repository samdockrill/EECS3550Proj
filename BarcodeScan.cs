using ZXing.Net.Maui;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using ZXing.Net.Maui.Controls;


namespace NutriWeekMAUI
{
    public class BarcodeScan
    {
        public BarcodeScan()
        {
            CameraBarcodeReaderView cameraView;
            Label resultLabel;
        }

        /*
        public BarcodeScanPage()
        {
            Title = "Scan Barcode";

            cameraView = new CameraBarcodeReaderView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                IsDetecting = true,
                IsTorchOn = false,
                AutomationId = "cameraView"
            };

            cameraView.BarcodesDetected += OnBarcodesDetected;

            resultLabel = new Label
            {
                Text = "Scan a barcode...",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            Content = new Grid
            {
                Children =
                {
                    cameraView,
                    resultLabel
                }
            };
        }

        private async void OnBarcodesDetected(object sender, BarcodeDetectionEventArgs e)
        {
            cameraView.IsDetecting = false;

            if(e.Results.FirstOrDefault() is BarcodeResult result)
            {
                string barcode = result.Value;
                string productName = await LookupProductName(barcode);

                await DisplayAlert("Product Found", productName, "OK");
            }
        }*/

        private async Task<string> LookupProductName(string barcode)
        {
            string url = $"https://world.openfoodfacts.org/api/v0/product/{barcode}.json";
        
            using var client = new HttpClient();
            try
            {
                var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return "Failed to fetch product.";

            string json = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(json);

            if (data["status"]?.ToString() == "1")
            {
                string productName = data["product"]?["product_name"]?.ToString();
                return string.IsNullOrWhiteSpace(productName) ? "Unnamed product" : productName;
            }

            return "Product not found.";
        }
        catch
        {
            return "Error fetching product.";
        }

            
        }

    }
}