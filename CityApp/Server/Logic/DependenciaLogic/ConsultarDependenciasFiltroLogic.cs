using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DependenciaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DependenciaLogic
{
    public class ConsultarDependenciasFiltroLogic
    {
        private DependenciaQuerys DependenciaQuerys;
        private List<Dependencia> Dependencia;
        private FiltroDependencia FiltroDependencia;


        public ConsultarDependenciasFiltroLogic(CityAppContext cityAppContex, FiltroDependencia filtroDependencia)
        {
            DependenciaQuerys = new DependenciaQuerys(cityAppContex);
            FiltroDependencia = filtroDependencia;
        }

        public Response<List<Dependencia>> Consultar()
        {
            Response<List<Dependencia>> response = new Response<List<Dependencia>>();

            Response<IEnumerable<Dependencia>> responseDependencia = DependenciaQuerys.SelectDependenciaFirltroDependencia(FiltroDependencia);
            response.Status = responseDependencia.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Dependencia>();    
                response.Data = responseDependencia.Data.ToList();
                response.Info = new Info();
                response.Info = responseDependencia.Info;
            }

            return response;
        }
    }
}
