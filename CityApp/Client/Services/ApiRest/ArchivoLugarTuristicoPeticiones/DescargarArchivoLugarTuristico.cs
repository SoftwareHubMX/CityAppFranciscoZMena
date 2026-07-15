using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoLugarTuristicoPeticiones
{
    public class DescargarArchivoLugarTuristico
    {
        private HttpClient Cliente;
        public DescargarArchivoLugarTuristico(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<byte[]>> DescargarArchivoLugarTuristicoAsync(string imagen, int idLugarTuristico)
        {
            Response<byte[]> response = new Response<byte[]>();

            string url = "ArchivoLugarTuristico/DescargarArchivoLugarTuristico";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Data = imagen;
            peticion.Identificador = idLugarTuristico.ToString();

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
