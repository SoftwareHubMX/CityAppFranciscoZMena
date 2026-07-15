using CityApp.Client.Services.ApiRest.DashBoardPeticiones;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.DashBoardLogic
{
    public class SelectLastIngresos
    {
        private DashBoardPeticiones DashBoardPeticiones;
        private Codificador Codificador = new Codificador();

        public SelectLastIngresos(HttpClient cliente)
        {
            DashBoardPeticiones = new DashBoardPeticiones(cliente);
        }

        public async Task<Response<List<UltimoPago>>> Select(string token)
        {
            Response<List<UltimoPago>> response = await DashBoardPeticiones.consultarUltimosIngresos(token);
            if(response.Status.Exito == 1)
            {
                for(int i = 0; i < response.Data.Count; i++)
                {
                    if (response.Data[i].Nombre != "NA")
                    {
                        response.Data[i].Nombre = Codificador.Decrypt(response.Data[i].Nombre);
                    }
                }
            }
            return response;
        }
    }
}
