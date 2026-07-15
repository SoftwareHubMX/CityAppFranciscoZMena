using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoLugarTuristicoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoPagoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoLugarTuristicoLogic
{
    public class ConsultaTiposLugarTuristicoLogic
    {
        private TipoLugarTuristicoQuerys TipoLugarTuristicoQuerys;

        public ConsultaTiposLugarTuristicoLogic(CityAppContext cityAppContext)
        {
            TipoLugarTuristicoQuerys = new TipoLugarTuristicoQuerys(cityAppContext);
        }

        public Response<List<TipoLugarTuristico>> Consultar()
        {
            Response<List<TipoLugarTuristico>> response = new Response<List<TipoLugarTuristico>>();

            Response<IEnumerable<TipoLugarTuristico>> responseTipoPago = TipoLugarTuristicoQuerys.SelectTiposLugarTuristico();
            response.Status = responseTipoPago.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseTipoPago.Data.ToList();
            }

            return response;
        }
    }
}
