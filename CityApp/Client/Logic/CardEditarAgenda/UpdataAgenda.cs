using CityApp.Client.Services.ApiRest.AgendaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarAgenda
{
    public class UpdataAgenda
    {
        private AgendaPeticiones AgendaPeticiones;

        public UpdataAgenda(HttpClient cliente)
        {
            AgendaPeticiones = new AgendaPeticiones(cliente);
        }

        public async Task<Response<object>> Updata(string token, Agenda agenda)
        {
            Response<object> response = await AgendaPeticiones.editarAgenda(token, agenda);
            return response;
        }
    }
}
