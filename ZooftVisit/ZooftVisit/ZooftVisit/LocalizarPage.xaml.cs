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
        private CoordenadaViewModel coordenadas;
        public List<Coordenada> listCoordenadas = new List<Coordenada>();
        public string lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        public LocalizarPage(CoordenadaViewModel coordenadaViewModel)
        {
            // https://xamarinlatino.com/google-maps-f%C3%A1cil-en-xamarin-forms-7b84d474b3f1
            // Usar el package Xamarin.Forms.Maps de Microsoft


            InitializeComponent();

            this.coordenadas = coordenadaViewModel;

            //Pin pin = new Pin()
            //{
            //    Position = new Position(40.40934544720297, -3.760961529100968),
            //    Label = "ZOO ACUARIUM"
            //};
            //map.Pins.Add(pin);

            CargarObjetos(coordenadas);
            GenerarUbicaciones();
        }

        private void CargarObjetos(CoordenadaViewModel coordenadas)
        {
            foreach (var item in coordenadas.Coordenadas.ToList())
            {
                Coordenada coordenada = new Coordenada()
                {
                    Id = item.Id,
                    Latitud = item.Latitud,
                    longitud = item.longitud,
                    Tipo = item.Tipo,
                    TituloEsp = item.TituloEsp,
                    TituloIng = item.TituloIng,
                    DescripcionEsp = item.DescripcionEsp,
                    DescripcionIng = item.DescripcionIng
                };

                listCoordenadas.Add(coordenada);
            }
        }

        public void GenerarUbicaciones()
        {
            var pins = new List<Pin>();

            for (int i = 0; i < listCoordenadas.Count; i++)
            {
                Pin pin = new Pin()
                {
                    Position = new Position(
                        Double.Parse(listCoordenadas[i].Latitud.ToString()),
                        Double.Parse(listCoordenadas[i].longitud.ToString()))
                };

                if (lang == "es")
                {
                    pin.Label = listCoordenadas[i].TituloEsp.ToString();
                    pin.Address = listCoordenadas[i].DescripcionEsp.ToString();
                }
                else
                {
                    pin.Label = listCoordenadas[i].TituloIng.ToString();
                    pin.Address = listCoordenadas[i].DescripcionIng.ToString();
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