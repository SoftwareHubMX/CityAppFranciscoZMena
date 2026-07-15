using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusBolsaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.StatusBolsaLogic
{
    public class ConsultarStatusBolsaLogic
    {
        private StatusBolsaQuerys StatusBolsaQuerys;

        public ConsultarStatusBolsaLogic(CityAppContext cityAppContext)
        {
            StatusBolsaQuerys = new StatusBolsaQuerys(cityAppContext);
        }

        public Response<List<StatusBolsa>> Consultar()
        {
            Response<List<StatusBolsa>> response = new Response<List<StatusBolsa>>();

            Response<IEnumerable<StatusBolsa>> responseEstatusBolsa = StatusBolsaQuerys.SelectStatusBolsa();
            response.Status = responseEstatusBolsa.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseEstatusBolsa.Data.ToList();
            }

            return response;
        }
    }
}
