using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys.Select
{
    public class IdsDependenciasSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdsDependenciasSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<int>> SelectIdsDependenciasIdSecretaria(int idSecretaria)
        {
            Response<IEnumerable<int>> response = new Response<IEnumerable<int>>();

            response.Data = from data in CityAppContext.Dependencias
                            where data.IdSecretaria == idSecretaria
                            select data.IdDependencia;

            response.Status = SelectCityApp.ValidarLista(response.Data);

            return response;
        }
    }
}
