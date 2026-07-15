using CityApp.Client.Services.ApiRest.TipoLugarTuisticoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarLugarturisticoLogic
{
    public class SelectTiposLugarTuristicos
    {
        private TipoLugarTuisticoPeticiones TipoLugarTuisticoPeticiones;

        public SelectTiposLugarTuristicos(HttpClient cliente)
        {
            TipoLugarTuisticoPeticiones = new TipoLugarTuisticoPeticiones(cliente);
        }

        public async Task<Response<List<TipoLugarTuristico>>> SelectAll()
        {
            Response<List<TipoLugarTuristico>> response = await TipoLugarTuisticoPeticiones.consultaTiposLugarTuristico();
            return response;
        }
    }
}
