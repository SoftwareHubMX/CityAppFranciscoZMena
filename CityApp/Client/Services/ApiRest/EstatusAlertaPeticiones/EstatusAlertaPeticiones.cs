using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.EstatusAlertaPeticiones
{
    public class EstatusAlertaPeticiones
    {
        private ConsultarEstatusAlerta ConsultarEstatusAlerta;

        public EstatusAlertaPeticiones(HttpClient cliente)
        {
            ConsultarEstatusAlerta = new ConsultarEstatusAlerta(cliente);
        }

        public async Task<Response<List<EstatusAlerta>>> consultarEstatusAlerta()
        {
            Response<List<EstatusAlerta>> response = await ConsultarEstatusAlerta.ConsultarEstatusAlertaAsync();
            return response;
        }
    }
}
