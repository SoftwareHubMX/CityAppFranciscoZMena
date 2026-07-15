using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitanteQuerys.Update
{
    public class SolicitanteUpdate
    {
        private UpdateCityApp<Solicitante> UpdateCityApp;

        public SolicitanteUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Solicitante>(cityAppContext);
        }

        public Response<object> UpdateSolicitante(Solicitante solicitante)
        {
            return UpdateCityApp.Save(solicitante);
        }
    }
}
