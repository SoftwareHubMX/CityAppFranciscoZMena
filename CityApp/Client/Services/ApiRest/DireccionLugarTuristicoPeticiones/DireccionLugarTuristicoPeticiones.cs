using CityApp.Shared.Models.ControllersModels.DireccionLugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.DireccionLugarTuristicoPeticiones
{
    public class DireccionLugarTuristicoPeticiones
    {
        private ActualizarDireccionLugarTuristicoPeticion ActualizarDireccionLugarTuristicoPeticion;

        public DireccionLugarTuristicoPeticiones(HttpClient cliente)
        {
            ActualizarDireccionLugarTuristicoPeticion = new ActualizarDireccionLugarTuristicoPeticion(cliente);
        }

        public async Task<Response<object>> actualizarDireccionLugarTuristicoPeticion(string token, ActualizarDireccionLugarTuristico actualizarDireccionLugarTuristico)
        {
            Response<object> response = await ActualizarDireccionLugarTuristicoPeticion.ActualizarDireccionLugarTuristicoAsync(token, actualizarDireccionLugarTuristico);
            return response;
        }
    }
}
