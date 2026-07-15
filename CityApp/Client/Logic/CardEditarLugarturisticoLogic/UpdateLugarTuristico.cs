using CityApp.Client.Services.ApiRest.LugarTuristicoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarLugarturisticoLogic
{
    public class UpdateLugarTuristico
    {
        private LugarTuristicoPeticiones LugarTuristicoPeticiones;

        public UpdateLugarTuristico(HttpClient cliente)
        {
            LugarTuristicoPeticiones = new LugarTuristicoPeticiones(cliente);
        }

        public async Task<Response<object>> Update(string token, LugarTuristico lugarTuristico)
        {
            Response<object> response = await LugarTuristicoPeticiones.editarLugarTuristico(token, lugarTuristico);
            return response;
        }
    }
}
