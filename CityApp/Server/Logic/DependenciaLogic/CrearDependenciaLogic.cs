using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DependenciaLogic
{
    public class CrearDependenciaLogic
    {
        private DependenciaQuerys DependenciaQuerys;

        private Dependencia Dependencia;

        public CrearDependenciaLogic(CityAppContext cityAppContext, Dependencia dependencia)
        {
            DependenciaQuerys = new DependenciaQuerys(cityAppContext);

            Dependencia = dependencia;
        }

        public Response<object> Crear()
        {
            return DependenciaQuerys.InsertDependencia(Dependencia);
        }
    }
}
