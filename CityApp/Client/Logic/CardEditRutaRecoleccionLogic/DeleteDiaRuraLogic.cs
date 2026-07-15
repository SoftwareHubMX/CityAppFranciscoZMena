using CityApp.Client.Services.ApiRest.DiaRutaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditRutaRecoleccionLogic
{
    public class DeleteDiaRuraLogic
    {
        private DiaRutaPeticiones DiaRutaPeticiones;

        public DeleteDiaRuraLogic(HttpClient cliente)
        {
            DiaRutaPeticiones = new DiaRutaPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, DiaRuta diaRuta)
        {

            Response<object> response = await DiaRutaPeticiones.eliminarDiaRuta(token, diaRuta);
            return response;
        }
    }
}
