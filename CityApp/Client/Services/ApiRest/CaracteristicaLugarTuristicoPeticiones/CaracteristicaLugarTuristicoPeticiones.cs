using CityApp.Shared.Models.ControllersModels.CaracteristicaLugarTuristicoEntredaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.CaracteristicaLugarTuristicoPeticiones
{
    public class CaracteristicaLugarTuristicoPeticiones
    {
        private AgregarCaracteristicaLugarTuristicoPeticion AgregarCaracteristicaLugarTuristicoPeticion;
        private EliminarCaracteristicaLugarTuristico EliminarCaracteristicaLugarTuristico;

        public CaracteristicaLugarTuristicoPeticiones(HttpClient cliente)
        {
            AgregarCaracteristicaLugarTuristicoPeticion = new AgregarCaracteristicaLugarTuristicoPeticion(cliente);
            EliminarCaracteristicaLugarTuristico = new EliminarCaracteristicaLugarTuristico(cliente);
        }

        public async Task<Response<object>> agregarCaracteristicaLugarTuristicoPeticion(string token, AgregarCaracteristicaLugarTuristico agregarCaracteristicaLugarTuristico)
        {
            Response<object> response = await AgregarCaracteristicaLugarTuristicoPeticion.AgregarCaracteristicaLugarTuristicoAsync(token, agregarCaracteristicaLugarTuristico);
            return response;
        }

        public async Task<Response<object>> eliminarCaracteristicaLugarTuristico(string token, int idCaracteristicaLugarTuristico)
        {
            Response<object> response = await EliminarCaracteristicaLugarTuristico.EliminarCaracteristicaLugarTuristicoAsync(token, idCaracteristicaLugarTuristico);
            return response;
        }
    }
}
