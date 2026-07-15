using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAlertaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoAlrtaRutaLogic
{
    public class ConsultarTiposAlertaRutaLogic
    {
        private TipoAlertaRutaQuerys TipoAlertaRutaQuerys;

        public ConsultarTiposAlertaRutaLogic(CityAppContext cityAppContext)
        {
            TipoAlertaRutaQuerys = new TipoAlertaRutaQuerys(cityAppContext);
        }

        public Response<List<TipoAlertaRuta>> Consultar()
        {
            Response<List<TipoAlertaRuta>> response = new Response<List<TipoAlertaRuta>>();

            Response<IEnumerable<TipoAlertaRuta>> responseTipoAlerta = TipoAlertaRutaQuerys.SelectTiposAlertaRuta();
            response.Status = responseTipoAlerta.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseTipoAlerta.Data.ToList();
            }
            return response;
        }
    }
}
