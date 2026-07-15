using CityApp.Client.Services.ApiRest.CitaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CitaEndradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaCitasLogic
{
    public class SelectFiltroCitasLogic
    {
        private CitaPeticiones CitaPeticiones;

        public SelectFiltroCitasLogic(HttpClient cliente)
        {
            CitaPeticiones = new CitaPeticiones(cliente);
        }

        public async Task<Response<List<Cita>>> SelectAll(string token, FiltroCitas filtroCitas)
        {
            Response<List<Cita>> response = await CitaPeticiones.consultarFiltroCitas(token, filtroCitas);
            return response;
        }
    }
}
