using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitanteQuerys.Delete
{
    public class SolicitanteDelete
    {
        private DeleteCityApp<Solicitante> DeleteCityApp;

        public SolicitanteDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Solicitante>(cityAppContext);
        }

        public Response<object> DeleteSolicitante(Solicitante solicitante)
        {
            return DeleteCityApp.Save(solicitante);
        }
    }
}
