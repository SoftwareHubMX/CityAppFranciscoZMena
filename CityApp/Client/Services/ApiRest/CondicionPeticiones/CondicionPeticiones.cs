using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.CondicionPeticiones
{
    public class CondicionPeticiones
    {
        private ConsultarCondiciones ConsultarCondiciones;

        public CondicionPeticiones(HttpClient cliente)
        {
            ConsultarCondiciones = new ConsultarCondiciones(cliente);
        }

        public async Task<Response<List<Condicion>>> consultarCondiciones()
        {
            Response<List<Condicion>> response = await ConsultarCondiciones.ConsultarCondicionesAsync();
            return response;
        }
    }
}
