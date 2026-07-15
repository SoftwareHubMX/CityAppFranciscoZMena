using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusAlertaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.EstatusAlertaLogic
{
    public class ConsultarEstatusAlertaLogic
    {
        private EstatusAlertaQuerys EstatusAlertaQuerys;

        public ConsultarEstatusAlertaLogic(CityAppContext cityAppContext)
        {
            EstatusAlertaQuerys = new EstatusAlertaQuerys(cityAppContext);
        }

        public Response<List<EstatusAlerta>> Consultar()
        {
            Response<List<EstatusAlerta>> response = new Response<List<EstatusAlerta>>();

            Response<IEnumerable<EstatusAlerta>> responseEstatusAlerta = EstatusAlertaQuerys.SelectEstatusAlerta();
            response.Status = responseEstatusAlerta.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseEstatusAlerta.Data.ToList();
            }

            return response;
        }
    }
}
