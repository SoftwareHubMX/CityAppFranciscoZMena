using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys.Select
{
    public class DependenciaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Dependencia> SelectCityApp = new SelectCityApp<Dependencia>();

        public DependenciaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Dependencia> SelectDependenciaIdDependencia(int idDependencia)
        {
            Response<Dependencia> response = new Response<Dependencia>();

            try
            {
                response.Data = CityAppContext.Dependencias.Where(d => d.IdDependencia == idDependencia).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
