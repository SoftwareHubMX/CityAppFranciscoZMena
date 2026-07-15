using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSolicitudPodaQuerys.Select
{
    public class ArchivoSolicitudPodaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoSolicitidPoda> SelectCityApp = new SelectCityApp<ArchivoSolicitidPoda>();

        public ArchivoSolicitudPodaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;

        }

        public Response<ArchivoSolicitidPoda> SelectArchivoSolicitudPoda(int idArchivoSolicitudPoda)
        {
            Response<ArchivoSolicitidPoda> response = new Response<ArchivoSolicitidPoda>();

            try
            {
                response.Data = CityAppContext.ArchivosSolicitidPoda.Where(d => d.IdArchivoSolicitudPoda == idArchivoSolicitudPoda).First();

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
