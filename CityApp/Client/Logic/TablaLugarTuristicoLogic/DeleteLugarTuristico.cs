using CityApp.Client.Services.ApiRest.LugarTuristicoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaLugarTuristicoLogic
{
    public class DeleteLugarTuristico
    {
        private LugarTuristicoPeticiones LugarTuristicoPeticiones;

        public DeleteLugarTuristico(HttpClient cliente)
        {
            LugarTuristicoPeticiones = new LugarTuristicoPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idLugarTuristico)
        {
            Response<object> response = await LugarTuristicoPeticiones.eliminarLugarTuristico(token, idLugarTuristico);
            return response;
        }
    }
}
