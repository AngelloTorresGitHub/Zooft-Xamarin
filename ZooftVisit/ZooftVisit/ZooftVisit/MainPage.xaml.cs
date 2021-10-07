using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        AnimalViewModel animalViewModel = new AnimalViewModel();

        HelperAnimal helper = new HelperAnimal();

        public MainPage()
        {
            InitializeComponent();
            this.btnEscaner.Clicked += BtnEscaner_Clicked;
        }

        private async void BtnEscaner_Clicked(object sender, EventArgs e)
        {
            try {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.TopText = "Escanea el Código QR";
                scanner.BottomText = "Escanea el Código QR";

                var resultado = await scanner.Scan();

                if (resultado != null) {
                    Animal animalselect = new Animal();

                    _ = Task.Run(async () =>
                      {
                          animalselect = await helper.GetAnimal(resultado.Text);
                      });


                    //Animal animalselect = animalViewModel.GetAnimal(resultado.Text);

                    this.lblPrueba.Text = animalselect.ToString();

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }
    }
}
