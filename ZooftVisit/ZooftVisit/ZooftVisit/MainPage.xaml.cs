using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZooftVisit.Helpers;
using ZooftVisit.Models;
using ZooftVisit.ViewModels;
using ZXing.Net.Mobile.Forms;

namespace ZooftVisit
{
    public partial class MainPage : ContentPage
    {
        AnimalViewModel animalSelect = new AnimalViewModel();

        public MainPage()
        {
            InitializeComponent();

            SeleccionarIdioma();

            this.btnEscaner.Clicked += BtnEscaner_Clicked;
        }

        private void SeleccionarIdioma()
        {
            string lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            if (lang == "es")
            {
                lblEscaner.Text = "Escanear el Código QR";
                lblLocalizar.Text = "Localizar";
                lblSalir.Text = "Salir";
                lblDiseng.Text = "Diseñado por:";
            }
            else
            {
                lblEscaner.Text = "Scan the QR Code";
                lblLocalizar.Text = "Locate";
                lblSalir.Text = "Exit";
                lblDiseng.Text = "Designed by:";
            }
        }

        private async void BtnEscaner_Clicked(object sender, EventArgs e)
        {
            try {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.TopText = "Escanea el Código QR";
                scanner.BottomText = "Escanea el Código QR";

                var resultado = await scanner.Scan();

                if (resultado != null) {

                    //AnimalViewModel animalSelect = new AnimalViewModel();
                    animalSelect.GetAnimal(resultado.Text);

                    NavigationPage animalPage = new NavigationPage(new AnimalPage(animalSelect));
                    Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(animalPage));

                    // Limpia el ViewModel
                    //animalSelect = null; 
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }
    }
}
