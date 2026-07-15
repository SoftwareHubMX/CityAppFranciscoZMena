using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoDirectorioPeticiones
{
    public class DescargarArchivoDirectorio
    {
        private HttpClient Cliente;
        public DescargarArchivoDirectorio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<byte[]>> DescargarArchivoDirectorioAsync(string imagen, int idDirectorio)
        {
            Response<byte[]> response = new Response<byte[]>();

            string url = "ArchivoDirectorio/DescargarArchivoDirectorio";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Data = imagen;
            peticion.Identificador = idDirectorio.ToString();

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
