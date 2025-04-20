namespace NutriWeekMAUI
{
    public BarcodeScan()
    {
        var scanner = newZXingScannerView
        {
            HorizontalOptions=LayoutOptions.FillAndExpand,
            VerticalOptions=LayoutOptions.FillAndExpand,
            IsScanning = true
        };

        scanner.OnScanResult += (result) =>
        {
            scanner.IsAnalyzing = false;

            Device.BeginInvokeOnMainThread(async () =>
            {
                string productName = LookupProductName(result.Text);
                DisplayAlert("Scanned Barcode", result.Text, "OK");
                scanner.IsAnalyzing = true;
            });
        };

        Content = new StackLayout
        {
            Children = {
                scanner
            }
        };
    
        private async Task<string> LookupProductName(string barcode)
        {
            string url = $"httpshttps://world.openfoodfacts.org/api/v0/product/{barcode}.json";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.getAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return("Failed to fetch product.");

                    string content = await response.Content.ReadAsStringAsync();
                    var data = JObject.Parse(content);

                    if(data["status"]?.ToString() == "1")
                    {
                        string productName = data["product"]?["product_name"]?.ToString();
                        return(string.IsNullOrWhiteSpace(productName) ? "Unnamed product" : productName);
                    }
                    else
                    {
                        return("Product not found.");
                    }
                }
                catch
                {
                    return("Error fetching product.");
                }
            }
        }
    
    }
}