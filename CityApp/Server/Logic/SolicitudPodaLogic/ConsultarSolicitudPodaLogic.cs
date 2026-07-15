using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSolicitudPodaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoJustificacionSolicitudQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SolicitudPodaLogic
{
    public class ConsultarSolicitudPodaLogic
    {
        private SolicitudPodaQuerys SolicitudPodaQuerys;
        //private DiaRutaQuerys DiaRutaQuerys;
        private TipoJustificacionSolicitudQuerys TipoJustificacionSolicitudQuerys;
        private SolicitusTipoJustificacionQuerys SolicitusTipoJustificacionQuerys;
        private ArchivoSolicitudPodaQuerys ArchivoSolicitudPodaQuerys;


        private int IdSolicitudPoda;
        private SolicitudPoda SolicitudPoda;

        public ConsultarSolicitudPodaLogic(CityAppContext cityAppContetx, int idSolicitudPoda)
        {
            SolicitudPodaQuerys = new SolicitudPodaQuerys(cityAppContetx);
            //DiaRutaQuerys = new DiaRutaQuerys(cityAppContetx);
            TipoJustificacionSolicitudQuerys = new TipoJustificacionSolicitudQuerys(cityAppContetx);
            SolicitusTipoJustificacionQuerys = new SolicitusTipoJustificacionQuerys(cityAppContetx);
            ArchivoSolicitudPodaQuerys = new ArchivoSolicitudPodaQuerys(cityAppContetx);
            IdSolicitudPoda = idSolicitudPoda;
        }

        public Response<SolicitudPoda> Consultar()
        {
            Response<SolicitudPoda> response = new Response<SolicitudPoda>();

            Response<SolicitudPoda> responseSolicitudPoda = SolicitudPodaQuerys.SelectSolicitudPodaIdSolicitudPoda(IdSolicitudPoda);
            response.Status = responseSolicitudPoda.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new SolicitudPoda();
                response.Data = responseSolicitudPoda.Data;


                Response<IEnumerable<ArchivoSolicitidPoda>> responseArchivos = new Response<IEnumerable<ArchivoSolicitidPoda>>();
                responseArchivos = ArchivoSolicitudPodaQuerys.SelectArchivoSolicitudPodaIdSolicitudPoda(response.Data.IdSolicitudPoda);
                if (responseArchivos.Status.Exito == 1)
                {
                    response.Data.ArchivosSolicitudPoda = new List<ArchivoSolicitidPoda>();
                    response.Data.ArchivosSolicitudPoda = responseArchivos.Data.ToList();
                }

                //Response<IEnumerable<DiaRuta>> responseDias = new Response<IEnumerable<DiaRuta>>();
                //responseDias = DiaRutaQuerys.SelectDiasRuta(responseRecolecion.Data.IdRutaRecoleccion);
                //if (responseDias.Status.Exito == 1)
                //{
                //    responseRecolecion.Data.DiasRuta = new List<DiaRuta>();
                //    responseRecolecion.Data.DiasRuta = responseDias.Data.ToList();
                //    for (int j = 0; j < responseRecolecion.Data.DiasRuta.Count; j++)
                //    {
                //        responseRecolecion.Data.DiasRuta[j].RutaRecoleccion = null;
                //    }
                //}
                Response<IEnumerable<SolicitudTipoJustificacion>> responseColoniaRuta = new Response<IEnumerable<SolicitudTipoJustificacion>>();
                responseColoniaRuta = SolicitusTipoJustificacionQuerys.SelectSolicitudTipoJustificacion(responseSolicitudPoda.Data.IdSolicitudPoda);
                if (responseColoniaRuta.Status.Exito == 1)
                {
                    responseSolicitudPoda.Data.SolicitudesTipoJustificaciones = new List<SolicitudTipoJustificacion>();
                    responseSolicitudPoda.Data.SolicitudesTipoJustificaciones = responseColoniaRuta.Data.ToList();
                    for (int j = 0; j < responseSolicitudPoda.Data.SolicitudesTipoJustificaciones.Count; j++)
                    {
                        responseSolicitudPoda.Data.SolicitudesTipoJustificaciones[j].SolicitudesPoda = null;
                        Response<TipoJustificacionSolicitud> responseColonia = new Response<TipoJustificacionSolicitud>();
                        responseColonia = TipoJustificacionSolicitudQuerys.SelectTipoJustificacionSolicitudIdTipoJustificacion(responseSolicitudPoda.Data.SolicitudesTipoJustificaciones[j].IdTipoJustificacionSolicitud);
                        if (responseColonia.Status.Exito == 1)
                        {
                            responseSolicitudPoda.Data.SolicitudesTipoJustificaciones[j].TiposJustificacionSolicitud = new TipoJustificacionSolicitud();
                            responseSolicitudPoda.Data.SolicitudesTipoJustificaciones[j].TiposJustificacionSolicitud = responseColonia.Data;
                        }
                    }
                }
            }
            return response;
        }
    }
}
