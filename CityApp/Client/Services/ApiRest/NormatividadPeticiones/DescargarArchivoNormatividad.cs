using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NormatividadPeticiones
{
    public class DescargarArchivoNormatividad
    {
        private HttpClient Cliente;
        public DescargarArchivoNormatividad(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<byte[]>> DescargarArchivoNormatividadAsync(string imagen)
        {
            Response<byte[]> response = new Response<byte[]>();

            string url = "Normatividad/DescargarArchivoNormatividad";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Data = imagen;

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
