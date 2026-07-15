using CityApp.Client.Services.ApiRest.AgendaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaAgendaLogic
{
    public class InsertAgenda
    {
        private AgendaPeticiones AgendaPeticiones;

        public InsertAgenda(HttpClient cliente)
        {
            AgendaPeticiones = new AgendaPeticiones(cliente);
        }

        public async Task<Response<int>> Insert(string token, Agenda agenda)
        {
            Response<int> response = await AgendaPeticiones.crearAgenda(token, agenda);
            return response;
        }
    }
}
