using CityApp.Client.Services.ApiRest.DashBoardPeticiones;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.DashBoardLogic
{
    public class SelectTiposLugarTuristico
    {
        private DashBoardPeticiones DashBoardPeticiones;

        public SelectTiposLugarTuristico(HttpClient cliente)
        {
            DashBoardPeticiones = new DashBoardPeticiones(cliente);
        }

        public async Task<Response<List<ChartData>>> Select(FechasDashBoard fechasDashBoard, string token)
        {
            Response<List<ChartData>> response = await DashBoardPeticiones.consultarTiposLugarTuristico(fechasDashBoard, token);
            return response;
        }
    }
}
