using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.EscolaridadPeticiones
{
    public class EscolaridadPeticiones
    {
        private ConsultarEscolaridades ConsultarEscolaridades;

        public EscolaridadPeticiones(HttpClient cliente)
        {
            ConsultarEscolaridades = new ConsultarEscolaridades(cliente);
        }

        public async Task<Response<List<Escolaridad>>> consultarEscolaridades()
        {
            Response<List<Escolaridad>> response = await ConsultarEscolaridades.ConsultarEscolaridadesAsync();
            return response;
        }
    }
}
