using CityApp.Client.Services.ApiRest.LugarTuristicoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarLugarturisticoLogic
{
    public class SelectLugarTuristico
    {
        private LugarTuristicoPeticiones LugarTuristicoPeticiones;

        public SelectLugarTuristico(HttpClient cliente)
        {
            LugarTuristicoPeticiones = new LugarTuristicoPeticiones(cliente);
        }

        public async Task<Response<LugarTuristico>> Select(int idLugarTuristico)
        {
            Response<LugarTuristico> response = await LugarTuristicoPeticiones.consultarLugarTuristico(idLugarTuristico);
            return response;
        }
    }
}
