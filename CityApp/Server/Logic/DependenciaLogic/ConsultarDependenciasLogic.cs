using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DependenciaLogic
{
    public class ConsultarDependenciasLogic
    {
        private DependenciaQuerys DependenciaQuerys;
        //private List<Dependencia> Dependencia = new List<Dependencia>();
        private  int IdDependencia = 0;



        public ConsultarDependenciasLogic(CityAppContext cityAppContex, int idDependencia)
        {
            DependenciaQuerys = new DependenciaQuerys(cityAppContex);
            IdDependencia = idDependencia;
        }

        public Response<List<Dependencia>> Consultar()
        {
            Response<List<Dependencia>> response = new Response<List<Dependencia>>();

            Response<IEnumerable<Dependencia>> responseDependencia = DependenciaQuerys.SelectDependencia(IdDependencia);
            response.Status = responseDependencia.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Dependencia>();
                response.Data = responseDependencia.Data.ToList();
            }

            return response;
        }
    }
}
