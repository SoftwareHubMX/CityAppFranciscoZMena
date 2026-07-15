using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TramiteLogic
{
    public class ConsultarTramiteLogic
    {
        private TramiteQuerys TramiteQuerys;
        

        private int IdTramite;
        private Tramite Tramite;

        public ConsultarTramiteLogic(CityAppContext cityAppContetx, int idTramite)
        {
            TramiteQuerys = new TramiteQuerys(cityAppContetx);
 
            IdTramite = idTramite;
        }

        public Response<Tramite> Consultar()
        {
            return TramiteQuerys.SelectTramiteIdTramite(IdTramite);
        }
    }
}
