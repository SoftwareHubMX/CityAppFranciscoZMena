using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys.Select
{
    public class ArchivoAnuncioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoAnuncio> SelectCityApp = new SelectCityApp<ArchivoAnuncio>();

        public ArchivoAnuncioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;

        }

        public Response<ArchivoAnuncio> SelectArchivoAnuncio(int idArchivoAnuncio)
        {
            Response<ArchivoAnuncio> response = new Response<ArchivoAnuncio>();

            try
            {
                response.Data = CityAppContext.ArchivosAnuncio.Where(d => d.IdArchivoAnuncio == idArchivoAnuncio).First();

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
