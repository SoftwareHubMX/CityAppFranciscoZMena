using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.EvidenciaSolucionReporteCiudadanoLogic
{
    public class EliminarEvidenciaSolucionReporteCiudadanoLogic
    {
        private EvidenciaSolucionReporteCiudadanoQuerys EvidenciaSolucionReporteCiudadanoQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private EvidenciaSolucionReporteCiudadano EvidenciaSolucionReporteCiudadano;

        public EliminarEvidenciaSolucionReporteCiudadanoLogic(CityAppContext cityAppContext, int idCuenta, int idEnvidenciaSolucionReporteCiudadano)
        {
            EvidenciaSolucionReporteCiudadanoQuerys = new EvidenciaSolucionReporteCiudadanoQuerys(cityAppContext);

            EvidenciaSolucionReporteCiudadano = new EvidenciaSolucionReporteCiudadano()
            {
                IdEnvidenciaSolucionReporteCiudadano = idEnvidenciaSolucionReporteCiudadano,
                IdCuenta = idCuenta,
            };
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<EvidenciaSolucionReporteCiudadano> responseEvidenciaSolucionReporteCiudadano = EvidenciaSolucionReporteCiudadanoQuerys.SelectEvidenciaSolucionReporteCiudadanoIdEvidenciaSolucionReporteCiudadano(EvidenciaSolucionReporteCiudadano.IdEnvidenciaSolucionReporteCiudadano);
            response.Status = responseEvidenciaSolucionReporteCiudadano.Status;
            if (response.Status.Exito == 1)
            {
                EvidenciaSolucionReporteCiudadano = responseEvidenciaSolucionReporteCiudadano.Data;
                response = EliminarArchivo();
                if (response.Status.Exito == 1)
                {
                    response = EvidenciaSolucionReporteCiudadanoQuerys.DeleteEvidenciaReporteCiudadano(EvidenciaSolucionReporteCiudadano);
                }
            }

            return response;
        }

        private Response<object> EliminarArchivo()
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaEvidenciaSolucionReporteCiudadano + EvidenciaSolucionReporteCiudadano.IdReporteCiudadano + "\\" + EvidenciaSolucionReporteCiudadano.Ruta;
            response = ServicioFicheros.ArchivoEliminar(ruta);

            return response;
        }
    }
}
