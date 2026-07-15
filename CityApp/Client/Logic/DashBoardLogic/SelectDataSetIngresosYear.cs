using CityApp.Client.Services.ApiRest.DashBoardPeticiones;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.DashBoardLogic
{
    public class SelectDataSetIngresosYear
    {
        private DashBoardPeticiones DashBoardPeticiones;

        public SelectDataSetIngresosYear(HttpClient cliente)
        {
            DashBoardPeticiones = new DashBoardPeticiones(cliente);
        }

        public async Task<Response<List<ChartData>>> Select(FechasDashBoard fechasDashBoard, string token)
        {
            Response<List<ChartData>> response = await DashBoardPeticiones.consultarDataSetIngresosYear(fechasDashBoard, token);
            return response;
        }
    }
}
