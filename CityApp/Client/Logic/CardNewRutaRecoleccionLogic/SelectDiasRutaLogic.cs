using CityApp.Client.Services.ApiRest.DiaRutaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewRutaRecoleccionLogic
{
    public class SelectDiasRutaLogic
    {
        private DiaRutaPeticiones DiaRutaPeticiones;

        public SelectDiasRutaLogic(HttpClient cliente)
        {
            DiaRutaPeticiones = new DiaRutaPeticiones(cliente);
        }

        public async Task<Response<List<DiaRuta>>> SelectAll(int idRutaRecoleccion)
        {
            Response<List<DiaRuta>> response = await DiaRutaPeticiones.consultarDiasRuta(idRutaRecoleccion);
            return response;
        }
    }
}
