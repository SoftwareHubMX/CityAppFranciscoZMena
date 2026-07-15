using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys.Insert
{
    public class DependenciaInsert
    {
        private InsertCityApp<Dependencia> InsertCityApp;

        public DependenciaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Dependencia>(cityAppContext);
        }

        public Response<object> InsertDependencia(Dependencia dependencia)
        {
            return InsertCityApp.Save(dependencia);
        }
    }
}
