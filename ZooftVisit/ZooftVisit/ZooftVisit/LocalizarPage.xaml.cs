using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using ZooftVisit.Helpers;
using ZooftVisit.Models;
using ZooftVisit.ViewModels;

namespace ZooftVisit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalizarPage : ContentPage
    {
        CoordenadaViewModel coordenadaViewModel = new CoordenadaViewModel();
        public string lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        public LocalizarPage()
        {
            // https://xamarinlatino.com/google-maps-f%C3%A1cil-en-xamarin-forms-7b84d474b3f1
            // Usar el package Xamarin.Forms.Maps de Microsoft

            InitializeComponent();

            //Pin pin = new Pin()
            //{
            //    Position = new Position(40.40934544720297, -3.760961529100968),
            //    Label = "ZOO ACUARIUM"
            //};
            //map.Pins.Add(pin);


            GenerarUbicaciones();
        }

        public void GenerarUbicaciones()
        {
            List<Pin> pins = new List<Pin>();        

            foreach (Coordenada coord in coordenadaViewModel.GetCoordenadas())
            {
                Pin pin = new Pin()
                {
                    Position = new Position(Double.Parse(coord.Latitud.ToString()), Double.Parse(coord.longitud.ToString()))
                };

                if (lang == "es")
                {
                    pin.Label = coord.TituloEsp.ToString();
                    pin.Address = coord.DescripcionEsp.ToString();
                }
                else
                {
                    pin.Label = coord.TituloIng.ToString();
                    pin.Address = coord.DescripcionIng.ToString();
                }

                pins.Add(pin);
            }

            foreach (Pin pin in pins)
            {
                map.Pins.Add(pin);
            }
        }
    }
}