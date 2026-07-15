using CityApp.Client.Services.ApiRest.EstatusAlertaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaAlertaLogic
{
    public class SelectEstausAlertas
    {
        private EstatusAlertaPeticiones EstatusAlertaPeticiones;

        public SelectEstausAlertas(HttpClient cliente)
        {
            EstatusAlertaPeticiones = new EstatusAlertaPeticiones(cliente);
        }

        public async Task<Response<List<EstatusAlerta>>> SelectAll()
        {
            Response<List<EstatusAlerta>> response = await EstatusAlertaPeticiones.consultarEstatusAlerta();
            return response;
        }
    }
}
