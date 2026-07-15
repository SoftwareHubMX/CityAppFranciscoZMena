using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAtencionContactoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoAtencionContactoLogic
{
    public class ConsultarTiposAtencionesContactoLogic
    {
        private TipoAtencionContactoQuerys TipoAtencionContactoQuerys;

        public ConsultarTiposAtencionesContactoLogic(CityAppContext cityAppContext)
        {
            TipoAtencionContactoQuerys = new TipoAtencionContactoQuerys(cityAppContext);
        }

        public Response<List<TipoAtencionContacto>> Consultar()
        {
            Response<List<TipoAtencionContacto>> response = new Response<List<TipoAtencionContacto>>();
            Response<IEnumerable<TipoAtencionContacto>> responseList = new Response<IEnumerable<TipoAtencionContacto>>();
            responseList = TipoAtencionContactoQuerys.SelectTiposAtencionesContacto();
            response.Status = responseList.Status;
            if(response.Status.Exito == 1)
            {
                response.Data = responseList.Data.ToList();
            }
            return response;
        }
    }
}
