using CityApp.Client.Services.ApiRest.ColoniaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewRutaRecoleccionLogic
{
    public class SelectColoniasLogic
    {
        private ColoniaPeticiones ColoniaPeticiones;

        public SelectColoniasLogic(HttpClient cliente)
        {
            ColoniaPeticiones = new ColoniaPeticiones(cliente);
        }

        public async Task<Response<List<Colonia>>> SelectAll()
        {
            Response<List<Colonia>> response = await ColoniaPeticiones.consultarColonias();
            return response;
        }
    }
}
