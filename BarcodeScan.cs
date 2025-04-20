using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace NutriWeekMAUI
{
    public class BarcodeScan
    {
    
    public BarcodeScan()
    {
        var scanner = newZXingScannerView; //Initalize scanner
        {
            //Scanner fill width and height and starts scanning
            HorizontalOptions=LayoutOptions.FillAndExpand,
            VerticalOptions=LayoutOptions.FillAndExpand,
            IsScanning = true
        };

        scanner.OnScanResult += (result) => //When barcode scanned
        {
            scanner.IsAnalyzing = false; //Stop Scanning

            Device.BeginInvokeOnMainThread(async () =>
            {
                string productName = LookupProductName(result.Text); //Call API to get info
                DisplayAlert("Scanned Barcode", result.Text, "OK"); //Confirm Scan happened
                scanner.IsAnalyzing = true; //Scan again
            });
        };

       /* Not sure if this is right or needed
       
       Content = new StackLayout
        {
            Children = {
                scanner 
            }
        }; */
    
        private async Task<string> LookupProductName(string barcode)
        {
            string url = $"httpshttps://world.openfoodfacts.org/api/v0/product/{barcode}.json"; //API endpoint

            using (var client = new HttpClient()) //client for web requests
            {
                try
                {
                    var response = await client.getAsync(url); //get request
                    if (!response.IsSuccessStatusCode)  //check for fail
                        return("Failed to fetch product."); //error message

                    string content = await response.Content.ReadAsStringAsync(); //read JSON
                    var data = JObject.Parse(content);  //Parse JSON into object

                    if(data["status"]?.ToString() == "1") //Product found?
                    {
                        string productName = data["product"]?["product_name"]?.ToString(); //Get name
                        return(string.IsNullOrWhiteSpace(productName) ? "Unnamed product" : productName);
                    }
                    else
                    {
                        return("Product not found."); //not found
                    }
                }
                catch
                {
                    return("Error fetching product."); //catch errors
                }
            }
        }
    }
    }
}