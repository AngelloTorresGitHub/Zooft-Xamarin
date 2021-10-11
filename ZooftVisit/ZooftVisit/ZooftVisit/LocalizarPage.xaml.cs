using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace ZooftVisit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalizarPage : ContentPage
    {
        public LocalizarPage()
        {
            InitializeComponent();
            //GenerarUbicacionesAsync();

            var defaultPin = new Pin
            {
                Type = PinType.Place,
                Label = "ZOO ACUARIUM",
                Address = "Here",
                Position = new Position(40.40934544720297, -3.760961529100968)
            };
            map.Pins.Add(defaultPin);
        }

        private async Task GenerarUbicacionesAsync()
        {

            try
            {
                var lat = 47.673988;
                var lon = -122.121513;

                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    var geocodeAddress =
                        $"AdminArea:       {placemark.AdminArea}\n" +
                        $"CountryCode:     {placemark.CountryCode}\n" +
                        $"CountryName:     {placemark.CountryName}\n" +
                        $"FeatureName:     {placemark.FeatureName}\n" +
                        $"Locality:        {placemark.Locality}\n" +
                        $"PostalCode:      {placemark.PostalCode}\n" +
                        $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                        $"SubLocality:     {placemark.SubLocality}\n" +
                        $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                        $"Thoroughfare:    {placemark.Thoroughfare}\n";

                    Console.WriteLine(geocodeAddress);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
            }
            //var map = new Map(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(10)));

            //var pin = new Pin()
            //{
            //    Position = new Position(37, -122),
            //    Label = "Some Pin!"
            //};
            //map.Pins.Add(pin);

            //var cp = new ContentPage
            //{
            //    Content = map,
            //};
        }
    }
}