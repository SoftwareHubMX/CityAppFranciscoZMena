using CityApp.Client.Services.ApiRest.DashBoardPeticiones;
using CityApp.Shared.Models.ControllersModels.DashBoardEntradaModels;
using CityApp.Shared.Models.ControllersModels.DashBoardSalidaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.DashBoardLogic
{
    public class SelectTotalBolsasTrabajo
    {
        private DashBoardPeticiones DashBoardPeticiones;

        public SelectTotalBolsasTrabajo (HttpClient cliente)
        {
            DashBoardPeticiones = new DashBoardPeticiones (cliente);
        }

        public async Task<Response<List<DataSet>>> Select(FiltroTotalBolsasTrabajo filtroTotalBolsasTrabajo, string token)
        {
            Response<List<DataSet>> response = await DashBoardPeticiones.consultarTotalesBolsasTrabajo(filtroTotalBolsasTrabajo, token);
            return response;
        }
    }
}
