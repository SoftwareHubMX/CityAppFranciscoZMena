using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusAlertaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.StatusAlertaRutaLogic
{
    public class ConsultarStatusAlertaRutaLogic
    {
        private StatusAlertaRutaQuerys StatusAlertaRutaQuerys;

        public ConsultarStatusAlertaRutaLogic(CityAppContext cityAppContext)
        {
            StatusAlertaRutaQuerys = new StatusAlertaRutaQuerys(cityAppContext);
        }

        public Response<List<StatusAlertaRuta>> Consultar()
        {
            Response<List<StatusAlertaRuta>> response = new Response<List<StatusAlertaRuta>>();

            Response<IEnumerable<StatusAlertaRuta>> responseStatusAlerta = StatusAlertaRutaQuerys.SelectStatusAlertaRuta();
            response.Status = responseStatusAlerta.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseStatusAlerta.Data.ToList();
            }

            return response;
        }
    }
}
