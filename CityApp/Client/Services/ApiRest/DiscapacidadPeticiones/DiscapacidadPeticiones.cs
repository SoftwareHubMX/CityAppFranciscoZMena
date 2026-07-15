using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.DiscapacidadPeticiones
{
    public class DiscapacidadPeticiones
    {
        private ConsultarDiscapacidades ConsultarDiscapacidades;

        public DiscapacidadPeticiones(HttpClient cliente)
        {
            ConsultarDiscapacidades = new ConsultarDiscapacidades(cliente);
        }

        public async Task<Response<List<Discapacidad>>> consultarDiscapacidades()
        {
            Response<List<Discapacidad>> response = await ConsultarDiscapacidades.ConsultarDiscapacidadesAsync();
            return response;
        }
    }
}
