using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSolicitudPodaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoJustificacionSolicitudQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SolicitanteEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SolicitudPodaLogic
{
    public class ConsultarFiltroSolicitudesPodaLogic
    {
        //private DiaRutaQuerys DiaRutaQuerys;
        private SolicitudPodaQuerys SolicitudPodaQuerys;
        private SolicitusTipoJustificacionQuerys SolicitusTipoJustificacionQuerys;
        private FiltroSolicitud FiltroSolicitud;
        private TipoJustificacionSolicitudQuerys TipoJustificacionSolicitudQuerys;
        private ArchivoSolicitudPodaQuerys ArchivoSolicitudPodaQuerys;


        public ConsultarFiltroSolicitudesPodaLogic(CityAppContext cityAppContex, FiltroSolicitud filtroSolicitud)
        {
            SolicitudPodaQuerys = new SolicitudPodaQuerys(cityAppContex);
            SolicitusTipoJustificacionQuerys = new SolicitusTipoJustificacionQuerys(cityAppContex);
            TipoJustificacionSolicitudQuerys = new TipoJustificacionSolicitudQuerys(cityAppContex);
            ArchivoSolicitudPodaQuerys = new ArchivoSolicitudPodaQuerys(cityAppContex);
            FiltroSolicitud = filtroSolicitud;
            //DiaRutaQuerys = new DiaRutaQuerys(cityAppContex);

        }

        public Response<List<SolicitudPoda>> Consultar()
        {
            Response<List<SolicitudPoda>> response = new Response<List<SolicitudPoda>>();

            Response<IEnumerable<SolicitudPoda>> responseSolicitudPoda = SolicitudPodaQuerys.SelectSolicitudPodaFiltroSolicitudPoda(FiltroSolicitud);
            response.Status = responseSolicitudPoda.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<SolicitudPoda>();
                response.Data = responseSolicitudPoda.Data.ToList();
                response.Info = new Info();
                response.Info = responseSolicitudPoda.Info;
                for (int i = 0; i < response.Data.Count; i++)
                {
                   
                        Response<IEnumerable<ArchivoSolicitidPoda>> responseArchivos = new Response<IEnumerable<ArchivoSolicitidPoda>>();
                        responseArchivos = ArchivoSolicitudPodaQuerys.SelectArchivoSolicitudPodaIdSolicitudPoda(response.Data[i].IdSolicitudPoda);
                        if (responseArchivos.Status.Exito == 1)
                        {
                            response.Data[i].ArchivosSolicitudPoda = new List<ArchivoSolicitidPoda>();
                            response.Data[i].ArchivosSolicitudPoda = responseArchivos.Data.ToList();
                        }
                   
                    //    Response<IEnumerable<DiaRuta>> responseDias = new Response<IEnumerable<DiaRuta>>();
                    //    responseDias = DiaRutaQuerys.SelectDiasRuta(response.Data[i].IdRutaRecoleccion);
                    //    if (responseDias.Status.Exito == 1)
                    //    {
                    //        response.Data[i].DiasRuta = new List<DiaRuta>();
                    //        response.Data[i].DiasRuta = responseDias.Data.ToList();
                    //        for (int j = 0; j < response.Data[i].DiasRuta.Count; j++)
                    //        {
                    //            response.Data[i].DiasRuta[j].RutaRecoleccion = null;
                    //        }
                    //    }
                    Response<IEnumerable<SolicitudTipoJustificacion>> responseSolicitudTipoJustificacion = new Response<IEnumerable<SolicitudTipoJustificacion>>();
                    responseSolicitudTipoJustificacion = SolicitusTipoJustificacionQuerys.SelectSolicitudTipoJustificacion(response.Data[i].IdSolicitudPoda);
                    if (responseSolicitudTipoJustificacion.Status.Exito == 1)
                    {
                        response.Data[i].SolicitudesTipoJustificaciones = new List<SolicitudTipoJustificacion>();
                        response.Data[i].SolicitudesTipoJustificaciones = responseSolicitudTipoJustificacion.Data.ToList();
                        for (int j = 0; j < response.Data[i].SolicitudesTipoJustificaciones.Count; j++)
                        {
                            response.Data[i].SolicitudesTipoJustificaciones[j].SolicitudesPoda = null;
                            Response<TipoJustificacionSolicitud> responseTipoJustificacion = new Response<TipoJustificacionSolicitud>();
                            responseTipoJustificacion = TipoJustificacionSolicitudQuerys.SelectTipoJustificacionSolicitudIdTipoJustificacion(response.Data[i].SolicitudesTipoJustificaciones[j].IdTipoJustificacionSolicitud);
                            if (responseTipoJustificacion.Status.Exito == 1)
                            {
                                response.Data[i].SolicitudesTipoJustificaciones[j].TiposJustificacionSolicitud = new TipoJustificacionSolicitud();
                                response.Data[i].SolicitudesTipoJustificaciones[j].TiposJustificacionSolicitud = responseTipoJustificacion.Data;
                                response.Data[i].SolicitudesTipoJustificaciones[j].SolicitudesPoda = null;
                            }
                        }
                    }
            }

        }

            return response;
        }
    }
}
