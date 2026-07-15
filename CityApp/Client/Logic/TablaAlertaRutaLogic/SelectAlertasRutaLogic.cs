using CityApp.Client.Services.ApiRest.AlertaRutaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaRutaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaAlertaRutaLogic
{
    public class SelectAlertasRutaLogic
    {
        private AlertaRutaPeticiones AlertaRutaPeticiones;
        

        public SelectAlertasRutaLogic(HttpClient cliente)
        {
            AlertaRutaPeticiones = new AlertaRutaPeticiones(cliente);
        }

        public async Task<Response<List<AlertaRuta>>> SelectAll(string token, FiltroAlertaRuta filtroAlertaRuta)
        {
            Response<List<AlertaRuta>> response = await AlertaRutaPeticiones.consultarFiltroAlertaRuta(token, filtroAlertaRuta);
            return response;
        }
    }
}
