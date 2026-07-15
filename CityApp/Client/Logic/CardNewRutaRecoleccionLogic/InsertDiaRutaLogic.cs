using CityApp.Client.Services.ApiRest.DiaRutaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewRutaRecoleccionLogic
{
    public class InsertDiaRutaLogic
    {
        private DiaRutaPeticiones DiaRutaPeticiones;

        public InsertDiaRutaLogic(HttpClient cliente)
        {
            DiaRutaPeticiones = new DiaRutaPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, DiaRuta diaRuta)
        {
            Response<object> response = await DiaRutaPeticiones.crearDiaRuta(token, diaRuta);
            return response;
        }
    }
}
