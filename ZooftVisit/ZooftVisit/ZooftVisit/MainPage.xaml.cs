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
//using ZXing.Net.Mobile.Forms;

namespace ZooftVisit
{
    public partial class MainPage : ContentPage
    {
        AnimalViewModel animalSelect = new AnimalViewModel();
        public String labelScan = "";
        public String salirAppTitle, salirApp, salirAppSI = "";
        public String salirAppNO = "No";

        public MainPage()
        {
            InitializeComponent();

            SeleccionarIdioma();

            btnEscaner.Clicked += BtnEscaner_Clicked;
            btnSalir.Clicked += BtnSalir_Clicked;
            btnLocalizar.Clicked += BtnLocalizar_Clicked;
            
        }

        private async void BtnLocalizar_Clicked(object sender, EventArgs e)
        {
            var localizarPage = new LocalizarPage();
            await this.Navigation.PushAsync(localizarPage);
        }

        private async void BtnSalir_Clicked(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/29257929/how-to-terminate-a-xamarin-application

            bool salir = await DisplayAlert(salirAppTitle, salirApp, salirAppSI, salirAppNO);

            if (salir)
            {
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }
            
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
                labelScan = "Escanea el Código QR";
                salirAppTitle = "Salir de la Aplicación";
                salirApp = "¿Desea salir de la Aplicacíon?";
                salirAppSI = "Si";
            }
            else
            {
                lblEscaner.Text = "Scan the QR Code";
                lblLocalizar.Text = "Locate";
                lblSalir.Text = "Exit";
                lblDiseng.Text = "Designed by:";
                labelScan = "Scan the QR Code";
                salirAppTitle = "Exit application";
                salirApp = "Do you want to exit the Application ? ";
                salirAppSI = "Yes";
            }
        }

        private async void BtnEscaner_Clicked(object sender, EventArgs e)
        {

            // Codigo QR
            // https://andresledo.es/csharp/xamarin/leer-codigos-barras-qr/
            // https://www.youtube.com/watch?v=mHl1LOgr_Tw&ab_channel=AguilarSystemsMX

            try
            {
                //var scanner = new ZXingScannerPage {
                //    DefaultOverlayTopText = "Escanea el Código QR",
                //    DefaultOverlayBottomText = "Escanea el Código QR"
                //};

                //await ZooftVisit.App.Current.MainPage.Navigation.PushAsync(scanner);

                //scanner.OnScanResult += (resultado) =>
                //{
                //    Device.BeginInvokeOnMainThread(async () => 
                //    {
                //        await Application.Current.MainPage.Navigation.PopModalAsync();

                //        if (!string.IsNullOrEmpty(resultado.Text))
                //        {
                //            animalSelect.GetAnimal(resultado.Text);

                //            NavigationPage animalPage = new NavigationPage(new AnimalPage(animalSelect));
                //            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(animalPage));
                //        }
                //    });
                //};


                var scanner = new ZXing.Mobile.MobileBarcodeScanner
                {
                    TopText = labelScan,
                    BottomText = labelScan
                };

                var resultado = await scanner.Scan();

                if (resultado != null)
                {
                    animalSelect.GetAnimal(resultado.Text);

                    // https://luismts.com/es/manejando-la-navegacion-en-xamarin-forms/
                    var animalPage = new AnimalPage(animalSelect);
                    await this.Navigation.PushAsync(animalPage);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }
    }
}
