using CityApp.Client.Services.ApiRest.DashBoardPeticiones;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.DashBoardLogic
{
    public class SelectComunicacion
    {
        private DashBoardPeticiones DashBoardPeticiones;

        public SelectComunicacion(HttpClient cliente)
        {
            DashBoardPeticiones = new DashBoardPeticiones(cliente);
        }

        public async Task<Response<List<ChartData>>> Select(FechasDashBoard fechasDashBoard, string token)
        {
            Response<List<ChartData>> response = await DashBoardPeticiones.consultarComunicacion(fechasDashBoard, token);
            return response;
        }
    }
}
