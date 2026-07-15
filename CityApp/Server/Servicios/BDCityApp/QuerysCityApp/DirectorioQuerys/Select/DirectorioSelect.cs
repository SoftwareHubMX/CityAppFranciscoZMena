using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys.Select
{
    public class DirectorioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Directorio> SelectCityApp = new SelectCityApp<Directorio>();

        public DirectorioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<Directorio> SelectDirectorioIdDirectorio(int idDirectorio)
        {
            Response<Directorio> response = new Response<Directorio>();

            try
            {
                response.Data = CityAppContext.Directorios.Where(d => d.IdDirectorio == idDirectorio).FirstOrDefault();

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
