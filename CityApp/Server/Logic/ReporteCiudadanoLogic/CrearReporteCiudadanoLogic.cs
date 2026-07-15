using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.VercionReporteCiudadanoQuerys;
using CityApp.Server.Servicios.Geocoding;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.GeolocalizacionModels;

namespace CityApp.Server.Logic.ReporteCiudadanoLogic
{
    public class CrearReporteCiudadanoLogic
    {
        private ReporteCiudadanoQuerys ReporteCiudadanoQuerys;
        private VercionReporteCiudadanoQuerys VercionReporteCiudadanoQuerys;

        //private ServicioGeocodingGoogle ServicioGeocodingGoogle = new ServicioGeocodingGoogle();

        private ReporteCiudadano ReporteCiudadano;

        public CrearReporteCiudadanoLogic(CityAppContext cityAppContex, int idCuenta, CrearReporteCiudadano crearReporteCiudadano)
        {
            ReporteCiudadanoQuerys = new ReporteCiudadanoQuerys(cityAppContex);
            VercionReporteCiudadanoQuerys = new VercionReporteCiudadanoQuerys(cityAppContex);

            ReporteCiudadano = new ReporteCiudadano()
            {
                IdTipoReporteCiudadano = crearReporteCiudadano.IdTipoReporteCiudadano,
                IdEstatusReporteCiudadano = 1,
                VercionesReporteCiudadano = new List<VercionReporteCiudadano>(),
            };

            ReporteCiudadano.VercionesReporteCiudadano.Add(new VercionReporteCiudadano()
            {
                Descripcion = crearReporteCiudadano.Descripcion,
                IdCuenta = idCuenta,
                DireccionReporteCiudadano = new DireccionReporteCiudadano()
                {
                    Latitud = crearReporteCiudadano.Latitud,
                    Longitud = crearReporteCiudadano.Longitud,
                    Localidad = crearReporteCiudadano.Localidad,
                    Colonia = crearReporteCiudadano.Colonia,
                    Calle = crearReporteCiudadano.Calle,
                    Numero = crearReporteCiudadano.Numero,
                    CodigoPostal = crearReporteCiudadano.CodigoPostal
                },
            });
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responseInsert = InsertarReporteCiudadano();
            response.Status = responseInsert.Status;
            if (response.Status.Exito == 1)
            {
                response = VercionReporteCiudadanoQuerys.SelectUltimoIdVercionReporteCiudadanoIdCuentaDescripcion(ReporteCiudadano.VercionesReporteCiudadano[0].IdCuenta, ReporteCiudadano.VercionesReporteCiudadano[0].Descripcion);
            }
            //Response<object> responseCordenadas = BuscarCordenadas();
            //response.Status = responseCordenadas.Status;
            //if (response.Status.Exito == 1)
            //{

            //}

            return response;
        }

        //private Response<object> BuscarCordenadas()
        //{
        //    Response<object> response = new Response<object>();

        //    Response<DireccionGeocoding> responseDireccion = ServicioGeocodingGoogle.Geocoding(ReporteCiudadano.VercionesReporteCiudadano[0].DireccionReporteCiudadano.Latitud, ReporteCiudadano.VercionesReporteCiudadano[0].DireccionReporteCiudadano.Longitud);
        //    response.Status = responseDireccion.Status;
        //    if (response.Status.Exito == 1)
        //    {
        //        ReporteCiudadano.VercionesReporteCiudadano[0].DireccionReporteCiudadano.Localidad = responseDireccion.Data.Localidad.ToLower();
        //        ReporteCiudadano.VercionesReporteCiudadano[0].DireccionReporteCiudadano.Colonia = responseDireccion.Data.Colonia.ToLower();
        //        ReporteCiudadano.VercionesReporteCiudadano[0].DireccionReporteCiudadano.Calle = responseDireccion.Data.Calle.ToLower();
        //        ReporteCiudadano.VercionesReporteCiudadano[0].DireccionReporteCiudadano.Numero = responseDireccion.Data.Numero;
        //        ReporteCiudadano.VercionesReporteCiudadano[0].DireccionReporteCiudadano.CodigoPostal = responseDireccion.Data.CodigoPostal;
        //    }

        //    return response;
        //}

        private Response<object> InsertarReporteCiudadano()
        {
            Response<object> response = new Response<object>();

            Response<int> responseIdReporteCiudadano = ReporteCiudadanoQuerys.SelectIdReporteCiudadanoReporteCiudadanoCordenadasEstatus(ReporteCiudadano);
            response.Status = responseIdReporteCiudadano.Status;
            if(response.Status.Exito == 1)
            {
                ReporteCiudadano.VercionesReporteCiudadano[0].IdReporteCiudadano = responseIdReporteCiudadano.Data;
                response = VercionReporteCiudadanoQuerys.InsertVercionReporteCiudadano(ReporteCiudadano.VercionesReporteCiudadano[0]);
            }
            else if (response.Status.Exito == 2)
            {
                response = ReporteCiudadanoQuerys.InsertReporteCiudadano(ReporteCiudadano);
            }

            return response;
        }
    }
}
