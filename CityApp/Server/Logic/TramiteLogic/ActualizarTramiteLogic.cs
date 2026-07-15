using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TramiteLogic
{
    public class ActualizarTramiteLogic
    {
        private TramiteQuerys TramiteQuerys;
        private Tramite Tramite;
        public ActualizarTramiteLogic(CityAppContext cityAppContext, Tramite tramite)
        {
            TramiteQuerys = new TramiteQuerys(cityAppContext);

            Tramite = tramite;
        }

        public Response<object> Actualizar()
        {
            return TramiteQuerys.UpdateTramite(Tramite);
        }
    }
}
