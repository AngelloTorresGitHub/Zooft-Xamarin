using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZooftVisit.Models;

namespace ZooftVisit.Helpers
{
    public class HelperZooft
    {
        private HttpClient CrearCliente()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/Json"));

            return httpClient;
        }

        // Trae al animal escaneado
        public async Task<Animal> GetAnimal(String url)
        {
            Animal animal = null;
            String peticion = url;
            var uri = new Uri(String.Format(peticion, String.Empty));

            HttpClient httpClient = CrearCliente();

            var respuesta = await httpClient.GetAsync(uri);

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                animal = JsonConvert.DeserializeObject<Animal>(contenido);
            }

            return animal;
        }

        // Trea todas las coordenadas
        public async Task<List<Coordenada>> GetCoordenadas()
        {
            List<Coordenada> listCoordenadas = null;

            String peticion = "https://zooft-10490-default-rtdb.firebaseio.com/coordenadas.json/";
            var uri = new Uri(String.Format(peticion, String.Empty));

            HttpClient httpClient = CrearCliente();

            var respuesta = await httpClient.GetAsync(uri);

            if (respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                listCoordenadas = JsonConvert.DeserializeObject<List<Coordenada>>(contenido);
            }
            return listCoordenadas;
        }
    }
}
