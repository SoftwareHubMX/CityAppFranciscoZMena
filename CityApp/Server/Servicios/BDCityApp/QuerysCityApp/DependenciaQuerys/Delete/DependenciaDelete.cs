using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys.Delete
{
    public class DependenciaDelete
    {
        private DeleteCityApp<Dependencia> DeleteCityApp;

        public DependenciaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Dependencia>(cityAppContext);
        }

        public Response<object> DeleteDependencia(Dependencia dependencia)
        {
            return DeleteCityApp.Save(dependencia);
        }
    }
}
