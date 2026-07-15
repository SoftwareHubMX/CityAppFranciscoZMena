using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TramiteLogic
{
    public class CrearTramiteLogic
    {
        private TramiteQuerys TramiteQuerys;

        private Tramite Tramite;

        public CrearTramiteLogic(CityAppContext cityAppContext, Tramite tramite)
        {
            TramiteQuerys = new TramiteQuerys(cityAppContext);

            Tramite = tramite;
        }

        public Response<object> Crear()
        {
            return TramiteQuerys.InsertTramite(Tramite);
        }
    }
}
