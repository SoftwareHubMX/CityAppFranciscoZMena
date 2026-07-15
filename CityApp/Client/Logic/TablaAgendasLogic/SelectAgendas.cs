using CityApp.Client.Services.ApiRest.AgendaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AgendaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaAgendasLogic
{
    public class SelectAgendas
    {
        private AgendaPeticiones AgendaPeticiones;

        public SelectAgendas(HttpClient cliente)
        {
            AgendaPeticiones = new AgendaPeticiones(cliente);
        }

        public async Task<Response<List<Agenda>>> SelectAll(FiltroAgenda filtroAgendas)
        {
            Response<List<Agenda>> response = await AgendaPeticiones.consultarAgendas(filtroAgendas);
            return response;
        }
    }
}
