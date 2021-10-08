﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    public partial class AnimalPage : ContentPage
    {
        private AnimalViewModel animalSelect;
        public Animal animal;

        public String imgPeso = "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";
        public String imgLongitud = "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";

        public AnimalPage(AnimalViewModel animalSelect)
        {
            InitializeComponent();
            this.animalSelect = animalSelect;

            cargarObjeto(animalSelect);

            cargarContenido();
        }

        private void cargarObjeto(AnimalViewModel animalSelect)
        {
            this.animal = new Animal
            {
                Id = int.Parse(animalSelect.Animal.Id.ToString()),
                IdZona = animalSelect.Animal.IdZona.ToString(),
                Nombre = animalSelect.Animal.Nombre.ToString(),
                EspNombre = animalSelect.Animal.EspNombre.ToString(),
                IngNombre = animalSelect.Animal.IngNombre.ToString(),
                Imagen = animalSelect.Animal.Imagen.ToString(),
                EspEspecie = animalSelect.Animal.EspEspecie.ToString(),
                IngEspecie = animalSelect.Animal.IngEspecie.ToString(),
                ImgEspecie = animalSelect.Animal.ImgEspecie.ToString(),
                EspAlimentacion = animalSelect.Animal.EspAlimentacion.ToString(),
                IngAlimentacion = animalSelect.Animal.IngAlimentacion.ToString(),
                ImgAlimentacion = animalSelect.Animal.ImgAlimentacion.ToString(),
                EspRegion = animalSelect.Animal.EspRegion.ToString(),
                IngRegion = animalSelect.Animal.IngRegion.ToString(),
                ImgRegion = animalSelect.Animal.ImgRegion.ToString(),
                Peso = animalSelect.Animal.Peso.ToString(),
                Longitud = animalSelect.Animal.Longitud.ToString(),
                EspConservacion = animalSelect.Animal.EspConservacion.ToString(),
                IngConservacion = animalSelect.Animal.IngConservacion.ToString(),
                ImgConservacion = animalSelect.Animal.ImgConservacion.ToString(),
                EspDescripcion = animalSelect.Animal.EspDescripcion.ToString(),
                IngDescripcion = animalSelect.Animal.IngDescripcion.ToString(),
                EspCostumbres = animalSelect.Animal.EspCostumbres.ToString(),
                IngCostumbres = animalSelect.Animal.IngCostumbres.ToString(),
                EspSabias = animalSelect.Animal.EspSabias.ToString(),
                IngSabias = animalSelect.Animal.IngSabias.ToString(),
            };
        }

        private void cargarContenido()
        {
            // Cargar imagenes
            ImgAnimal.Source = Base64StringToImageSource(animal.Imagen);
            ImgEspecie.Source = Base64StringToImageSource(animal.ImgEspecie);
            ImgAlimentacion.Source = Base64StringToImageSource(animal.ImgAlimentacion);
            ImgRegion.Source = Base64StringToImageSource(animal.ImgRegion);
            ImgPeso.Source = Base64StringToImageSource(imgPeso);
            ImgLongitud.Source = Base64StringToImageSource(imgLongitud);
            ImgConservacion.Source = Base64StringToImageSource(animal.ImgConservacion);

            // Carga labels comunes para lo dos idiomas
            lblPeso.Text = animal.Peso.ToString();
            lblLongitud.Text = animal.Longitud.ToString();

            string lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            //Carga labels según el idioma
            if (lang == "es")
            {
                lblAnimal.Text = animal.EspNombre.ToString();
                lblEspecie.Text = animal.EspEspecie.ToString();
                lblAlimentacion.Text = animal.EspAlimentacion.ToString();
                lblRegion.Text = animal.EspRegion.ToString();
                lblConservacion.Text = animal.EspConservacion.ToString();
                lblTitleDescripcion.Text = "¿quién es?";
                lblDescripcion.Text = animal.EspDescripcion.ToString();
                lblTitleCostumbres.Text = "¿cuáles son sus costumbres?";
                lblCostumbres.Text = animal.EspCostumbres.ToString();
                lblTitleSabias.Text = "sabías que...";
                lblSabias.Text = animal.EspSabias.ToString();
            }
            else
            {
                lblAnimal.Text = animal.IngNombre.ToString();
                lblEspecie.Text = animal.IngEspecie.ToString();
                lblAlimentacion.Text = animal.IngAlimentacion.ToString();
                lblRegion.Text = animal.IngRegion.ToString();
                lblConservacion.Text = animal.IngConservacion.ToString();
                lblTitleDescripcion.Text = "who is it?";
                lblDescripcion.Text = animal.IngDescripcion.ToString();
                lblTitleCostumbres.Text = "what are its habits?";
                lblCostumbres.Text = animal.IngCostumbres.ToString();
                lblTitleSabias.Text = "did you know...";
                lblSabias.Text = animal.IngSabias.ToString();
            }
        }

        public ImageSource Base64StringToImageSource(string source)
        {
            var byteArray = Convert.FromBase64String(source);
            Stream stream = new MemoryStream(byteArray);
            return ImageSource.FromStream(() => stream);
        }
    }
}