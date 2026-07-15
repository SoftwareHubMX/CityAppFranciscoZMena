using CityApp.Client.Services.ApiRest.LugarTuristicoPeticiones;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevoLugarTuristicoLogic
{
    public class InsertLugarTuristico
    {
        private LugarTuristicoPeticiones LugarTuristicoPeticiones;

        public InsertLugarTuristico(HttpClient cliente)
        {
            LugarTuristicoPeticiones = new LugarTuristicoPeticiones(cliente);
        }

        public async Task<Response<int>> Insert(string token, CrearLugarTuristico crearLugarTuristico)
        {
            Response<int> response = await LugarTuristicoPeticiones.crearLugarTuristicoPeticion(token, crearLugarTuristico);
            return response;
        }
    }
}
