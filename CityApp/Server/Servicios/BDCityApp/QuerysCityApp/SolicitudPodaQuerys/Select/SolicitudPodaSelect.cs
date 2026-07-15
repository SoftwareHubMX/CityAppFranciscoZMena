using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys.Select
{
    public class SolicitudPodaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<SolicitudPoda> SelectCityApp = new SelectCityApp<SolicitudPoda>();

        public SolicitudPodaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<SolicitudPoda> SelectSolicitudPodaIdSolicitudPoda(int idSolicitudPoda)
        {
            Response<SolicitudPoda> response = new Response<SolicitudPoda>();

            try
            {
                response.Data = CityAppContext.SolicitudesPoda.Where(d => d.IdSolicitudPoda == idSolicitudPoda).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<SolicitudPoda> SelectLastIdSolicitudPoda()
        {
            Response<SolicitudPoda> response = new Response<SolicitudPoda>();

            try
            {
                response.Data = CityAppContext.SolicitudesPoda.OrderBy(d => d.IdSolicitudPoda).LastOrDefault();

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
