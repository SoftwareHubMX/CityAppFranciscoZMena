using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys.Insert
{
    public class TramiteInsert
    {
        private InsertCityApp<Tramite> InsertCityApp;
        public TramiteInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Tramite>(cityAppContext);
        }
        public Response<object> InsertTramite(Tramite tramite)
        {
            return InsertCityApp.Save(tramite);
        }
    }
}
