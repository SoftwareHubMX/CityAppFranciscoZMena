using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AnunciaoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AnuncioPeticiones
{
    public class ConsultarAnuncios
    {
        private HttpClient Cliente;
        public ConsultarAnuncios(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Anuncio>>> ConsultarAnunciosAsync(string token, FiltroAnuncio filtroAnuncio)
        {
            Response<List<Anuncio>> response = new Response<List<Anuncio>>();

            string url = "Anuncio/ConsultarAnunciosFiltro";
            Peticion<FiltroAnuncio> peticion = new Peticion<FiltroAnuncio>();
            peticion.Token = token;
            peticion.Data = filtroAnuncio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroAnuncio>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Anuncio>>>().Result;
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
