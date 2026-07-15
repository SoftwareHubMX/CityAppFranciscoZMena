using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.StatusBolsaTrabajoPeticiones
{
    public class StatusBolsaPeticiones
    {
        private ConsultarStatusBolsa ConsultarStatusBolsa;

        public StatusBolsaPeticiones(HttpClient cliente)
        {
            ConsultarStatusBolsa = new ConsultarStatusBolsa(cliente);
        }

        public async Task<Response<List<StatusBolsa>>> consultarStatusBolsa()
        {
            Response<List<StatusBolsa>> response = await ConsultarStatusBolsa.ConsultarStatusBolsaAsync();
            return response;
        }
    }
}
