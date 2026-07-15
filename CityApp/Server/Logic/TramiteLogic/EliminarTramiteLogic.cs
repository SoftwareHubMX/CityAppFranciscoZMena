using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TramiteLogic
{
    public class EliminarTramiteLogic
    {
        private TramiteQuerys TramiteQuerys;

        private int IdTramite;

        public EliminarTramiteLogic(CityAppContext cityAppContext, int idTramite)
        {
            TramiteQuerys = new TramiteQuerys(cityAppContext);

            IdTramite = idTramite;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Tramite> responseTramite = TramiteQuerys.SelectTramiteIdTramite(IdTramite);
            response.Status = responseTramite.Status;
            if (response.Status.Exito == 1)
            {
                response = TramiteQuerys.DeleteTramite(responseTramite.Data);
            }

            return response;
        }
    }
}
