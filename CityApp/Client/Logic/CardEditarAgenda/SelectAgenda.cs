using CityApp.Client.Services.ApiRest.AgendaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarAgenda
{
    public class SelectAgenda
    {
        private AgendaPeticiones AgendaPeticiones;

        public SelectAgenda(HttpClient cliente)
        {
            AgendaPeticiones = new AgendaPeticiones(cliente);
        }

        public async Task<Response<Agenda>> Select(int idAgenda)
        {
            Response<Agenda> response = await AgendaPeticiones.consultarAgenda(idAgenda);
            return response;
        }
    }
}
