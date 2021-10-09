using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZooftVisit.Models;
using ZooftVisit.ViewModels;

namespace ZooftVisit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncidenciasPage : ContentPage
    {
        private Animal animal;
        SubTiposViewModel subTiposViewModel = new SubTiposViewModel();

        public IncidenciasPage()
        {
            InitializeComponent();
            cargarContenido();
        }

        private void cargarContenido()
        {
            string lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            if (lang == "es") 
            {
                lblTitleIncidencia.Text = "Formulario de incidencia";
                lblTextIncidencia.Text = "Seleccione:";
            }
            else
            {
                lblTitleIncidencia.Text = "Incident form";
                lblTextIncidencia.Text = "Please select:";
            }

            lstVwSubtipos.BindingContext = subTiposViewModel;
            subTiposViewModel.GetSubtipos();
        }

        public IncidenciasPage(Animal animal)
        {
            this.animal = animal;
        }
    }
}