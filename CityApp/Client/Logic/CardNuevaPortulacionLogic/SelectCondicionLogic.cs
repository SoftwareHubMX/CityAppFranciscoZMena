using CityApp.Client.Services.ApiRest.CondicionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaPortulacionLogic
{
    public class SelectCondicionLogic
    {
        private CondicionPeticiones CondicionPeticiones;

        public SelectCondicionLogic(HttpClient cliente)
        {
            CondicionPeticiones = new CondicionPeticiones(cliente);
        }

        public async Task<Response<List<Condicion>>> SelectAll()
        {
            Response<List<Condicion>> response = await CondicionPeticiones.consultarCondiciones();
            return response;
        }
    }
}
