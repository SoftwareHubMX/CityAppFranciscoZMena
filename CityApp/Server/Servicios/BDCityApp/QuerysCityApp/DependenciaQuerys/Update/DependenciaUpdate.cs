using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys.Update
{
    public class DependenciaUpdate
    {
        private UpdateCityApp<Dependencia> UpdateCityApp;

        public DependenciaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Dependencia>(cityAppContext);
        }
        public Response<object> UpdateDependencia(Dependencia dependencia)
        {
            return UpdateCityApp.Save(dependencia);
        }
    }
}
