using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys.Select
{
    public class ArchivoDirectorioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoDirectorio> SelectCityApp = new SelectCityApp<ArchivoDirectorio>();

        public ArchivoDirectorioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
           
        }

        public Response<ArchivoDirectorio> SelectArchivoDirectorio(int idArchivoDirectorio)
        {
            Response<ArchivoDirectorio> response = new Response<ArchivoDirectorio>();

            try
            {
                response.Data = CityAppContext.ArchivosDirectorio.Where(d => d.IdArchivoDirectorio == idArchivoDirectorio).First();

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
