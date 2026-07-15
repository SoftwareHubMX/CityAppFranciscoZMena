using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoCitaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoCitaLogic
{
    public class ConsultarTiposCitaLogic
    {
        private TipoCitaQuerys TipoCitaQuerys;

        public ConsultarTiposCitaLogic(CityAppContext cityAppContext)
        {
            TipoCitaQuerys = new TipoCitaQuerys(cityAppContext);
        }

        public Response<List<TipoCita>> Consultar()
        {
            Response<List<TipoCita>> response = new Response<List<TipoCita>>();

            Response<IEnumerable<TipoCita>> responseTipoPago = TipoCitaQuerys.SelectTiposCita();
            response.Status = responseTipoPago.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseTipoPago.Data.ToList();
            }

            return response;
        }
    }
}
