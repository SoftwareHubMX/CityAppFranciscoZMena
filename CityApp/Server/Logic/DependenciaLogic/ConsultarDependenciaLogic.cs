using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DependenciaLogic
{
    public class ConsultarDependenciaLogic
    {
        private DependenciaQuerys DependenciaQuerys;


        private int IdDependencia;
        private Dependencia Dependencia;

        public ConsultarDependenciaLogic(CityAppContext cityAppContetx, int idDependencia)
        {
            DependenciaQuerys = new DependenciaQuerys(cityAppContetx);

            IdDependencia = idDependencia;
        }

        public Response<Dependencia> Consultar()
        {
            return DependenciaQuerys.SelectDependenciaIdDependencia(IdDependencia);
        }
    }
}
