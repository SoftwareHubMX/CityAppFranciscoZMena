using CityApp.Client.Services.ApiRest.CaracteristicaLugarTuristicoPeticiones;
using CityApp.Shared.Models.ControllersModels.CaracteristicaLugarTuristicoEntredaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarLugarturisticoLogic
{
    public class InsertCaracteristicaLugarTuristico
    {
        private CaracteristicaLugarTuristicoPeticiones CaracteristicaLugarTuristicoPeticiones;

        public InsertCaracteristicaLugarTuristico(HttpClient cliente)
        {
            CaracteristicaLugarTuristicoPeticiones = new CaracteristicaLugarTuristicoPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, AgregarCaracteristicaLugarTuristico agregarCaracteristicaLugarTuristico)
        {
            Response<object> response = await CaracteristicaLugarTuristicoPeticiones.agregarCaracteristicaLugarTuristicoPeticion(token, agregarCaracteristicaLugarTuristico);
            return response;
        }
    }
}
