using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusPagoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.EstatusPagoLogic
{
    public class ConsultarEstatusPagosLogic
    {
        private EstatusPagoQuerys EstatusPagoQuerys;

        public ConsultarEstatusPagosLogic(CityAppContext cityAppContext)
        {
            EstatusPagoQuerys = new EstatusPagoQuerys(cityAppContext);
        }

        public Response<List<EstatusPago>> Consultar()
        {
            Response<List<EstatusPago>> response = new Response<List<EstatusPago>>();

            Response<IEnumerable<EstatusPago>> responseEstatusPago = EstatusPagoQuerys.SelectEstatusPagos();
            response.Status = responseEstatusPago.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseEstatusPago.Data.ToList();
            }

            return response;
        }
    }
}
