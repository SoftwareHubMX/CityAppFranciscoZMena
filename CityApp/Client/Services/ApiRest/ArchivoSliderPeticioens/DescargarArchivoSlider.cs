using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoSliderPeticioens
{
    public class DescargarArchivoSlider
    {
        private HttpClient Cliente;
        public DescargarArchivoSlider(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<byte[]>> DescargarArchivoSliderAsync(string imagen, int idSlider)
        {
            Response<byte[]> response = new Response<byte[]>();

            string url = "ArchivoSlider/DescargarArchivoSlider";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Data = imagen;
            peticion.Identificador = idSlider.ToString();

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<string>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<byte[]>>().Result;
            }
            else
            {
                response.Status.Mensaje = "Error: "
                    + "\n Status: " + responsePeticion.StatusCode.ToString()
                    + "\n Alerta: " + responsePeticion.ReasonPhrase;
            }

            return response;
        }
    }
}
