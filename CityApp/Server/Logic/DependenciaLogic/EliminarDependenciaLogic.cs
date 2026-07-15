using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DependenciaLogic
{
    public class EliminarDependenciaLogic
    {
        private DependenciaQuerys DependenciaQuerys;

        private int IdDependencia;

        public EliminarDependenciaLogic(CityAppContext cityAppContext, int idDependencia)
        {
            DependenciaQuerys = new DependenciaQuerys(cityAppContext);

            IdDependencia = idDependencia;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Dependencia> responseSecretaria = DependenciaQuerys.SelectDependenciaIdDependencia(IdDependencia);
            response.Status = responseSecretaria.Status;
            if (response.Status.Exito == 1)
            {
                response = DependenciaQuerys.DeleteDependencia(responseSecretaria.Data);
            }

            return response;
        }
    }
}
