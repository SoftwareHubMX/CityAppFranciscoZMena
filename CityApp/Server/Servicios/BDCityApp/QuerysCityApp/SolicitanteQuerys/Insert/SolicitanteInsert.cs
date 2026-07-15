using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitanteQuerys.Insert
{
    public class SolicitanteInsert
    {
        private InsertCityApp<Solicitante> InsertCityApp;

        public SolicitanteInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Solicitante>(cityAppContext);
        }

        public Response<object> InsertSolicitante(Solicitante solicitante)
        {
            return InsertCityApp.Save(solicitante);
        }
    }
}
