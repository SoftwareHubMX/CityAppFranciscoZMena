using CityApp.Client.Services.ApiRest.DireccionLugarTuristicoPeticiones;
using CityApp.Shared.Models.ControllersModels.DireccionLugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevoLugarTuristicoLogic
{
    public class UpdataDireccionLugarTuristico
    {
        private DireccionLugarTuristicoPeticiones DireccionLugarTuristicoPeticiones;

        public UpdataDireccionLugarTuristico(HttpClient cliente)
        {
            DireccionLugarTuristicoPeticiones = new DireccionLugarTuristicoPeticiones(cliente);
        }

        public async Task<Response<object>> Updata(string token, ActualizarDireccionLugarTuristico actualizarDireccionLugarTuristico)
        {
            Response<object> response = await DireccionLugarTuristicoPeticiones.actualizarDireccionLugarTuristicoPeticion(token, actualizarDireccionLugarTuristico);
            return response;
        }
    }
}
