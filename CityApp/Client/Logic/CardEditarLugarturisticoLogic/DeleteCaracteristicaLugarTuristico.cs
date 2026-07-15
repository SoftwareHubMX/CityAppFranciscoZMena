using CityApp.Client.Services.ApiRest.CaracteristicaLugarTuristicoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarLugarturisticoLogic
{
    public class DeleteCaracteristicaLugarTuristico
    {
        private CaracteristicaLugarTuristicoPeticiones CaracteristicaLugarTuristicoPeticiones;

        public DeleteCaracteristicaLugarTuristico(HttpClient cliente)
        {
            CaracteristicaLugarTuristicoPeticiones = new CaracteristicaLugarTuristicoPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idCaracteristicaLugarTuristico)
        {
            Response<object> response = await CaracteristicaLugarTuristicoPeticiones.eliminarCaracteristicaLugarTuristico(token, idCaracteristicaLugarTuristico);
            return response;
        }
    }
}
