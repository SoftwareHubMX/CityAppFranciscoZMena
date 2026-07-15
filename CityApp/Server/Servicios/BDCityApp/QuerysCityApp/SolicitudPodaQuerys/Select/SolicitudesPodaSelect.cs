using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SolicitanteEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys.Select
{
    public class SolicitudesPodaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<SolicitudPoda> SelectCityApp = new SelectCityApp<SolicitudPoda>();
        private Paginado<SolicitudPoda> Paginado = new Paginado<SolicitudPoda>();

        public SolicitudesPodaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<SolicitudPoda>> SelectSolicitudesPoda()
        {
            Response<IEnumerable<SolicitudPoda>> response = new Response<IEnumerable<SolicitudPoda>>();

            try
            {
                response.Data = CityAppContext.SolicitudesPoda;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<SolicitudPoda>> SelectSolicitudPodaFiltroSolicitudPoda(FiltroSolicitud filtroSolicitud)
        {
            Response<IEnumerable<SolicitudPoda>> response = new Response<IEnumerable<SolicitudPoda>>();

            try
            {
                response.Data = CityAppContext.SolicitudesPoda.Where(
                    d => d.SolicitudesTipoJustificaciones.Any(
                        data => (filtroSolicitud.IdTipoJustificacioSolicitud > 0) ? data.IdTipoJustificacionSolicitud == filtroSolicitud.IdTipoJustificacioSolicitud : true));
                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroSolicitud.MaximoNoticias, filtroSolicitud.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
