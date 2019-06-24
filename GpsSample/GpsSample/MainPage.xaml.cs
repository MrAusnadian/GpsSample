using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GpsSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetGpsLocation();
        }

        public async void GetGpsLocation()
        {
            int i = 0;
            do
            {
                try
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    var location = await Geolocation.GetLocationAsync(request);
                    if (location != null)
                    {
                        Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                        LabelLatitude.Text = $"Latitude: {location.Latitude}";
                        LabelLongitude.Text = $"Longitude: {location.Longitude}";
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    await DisplayAlert("Error1", fnsEx.ToString(), "ok");
                }
                catch (PermissionException pEx)
                {
                    await DisplayAlert("Error2", pEx.ToString(), "ok");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error3", ex.ToString(), "ok");
                }
                Thread.Sleep(1000);
                i++;
            } while (LabelLatitude.Text == "Loading..." && i < 5);

            if (i >= 5)
            {
                LabelLatitude.Text = "Failed!";
                LabelLongitude.Text = "An unknown error occured.";
            }
        }
    }
}
