using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace BarCodeScanner
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            Button scanBtn = new Button
            {
                Text = "Scan Barcode",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            scanBtn.Clicked += async (sender, args) =>
            {
                var scanResult = await Acr.BarCodes.BarCodes.Instance.Read();
                if (!scanResult.Success)
                {
                    await this.DisplayAlert("Alert ! ", "Sorry ! \n Failed to read the Barcode !", "OK");
                }
                else
                {
                    await this.DisplayAlert("Scan Successful !", String.Format("Barcode Format : {0} \n Barcode Value : {1}", scanResult.Format, scanResult.Code), "OK");
                }
            };

            Content = new StackLayout
            {
                Children = {
                    scanBtn
				}
            };
        }
    }
}
