using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.GiroPeticiones
{
    public class GiroPeticiones
    {
        private ConsultarGiros ConsultarGiros;

        public GiroPeticiones(HttpClient cliente)
        {
            ConsultarGiros = new ConsultarGiros(cliente);
        }

        public async Task<Response<List<Giro>>> consultarGiros()
        {
            Response<List<Giro>> response = await ConsultarGiros.ConsultarGirosAsync();
            return response;
        }
    }
}
