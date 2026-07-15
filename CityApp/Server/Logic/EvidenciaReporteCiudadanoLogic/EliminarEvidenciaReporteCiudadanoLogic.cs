using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.EvidenciaReporteCiudadanoLogic
{
    public class EliminarEvidenciaReporteCiudadanoLogic
    {
        private EvidenciaReporteCiudadanoQuerys EvidenciaReporteCiudadanoQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private int IdEvidenciaReporteCiudadano;

        private EvidenciaReporteCiudadano EvidenciaReporteCiudadano;

        public EliminarEvidenciaReporteCiudadanoLogic(CityAppContext cityAppContext, int idEvidenciaReporteCiudadano)
        {
            EvidenciaReporteCiudadanoQuerys = new EvidenciaReporteCiudadanoQuerys(cityAppContext);

            IdEvidenciaReporteCiudadano = idEvidenciaReporteCiudadano;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<EvidenciaReporteCiudadano> responseEvidenciaReporteCiudadano = EvidenciaReporteCiudadanoQuerys.SelectEvidenciaReporteCiudadanoIdEnvidenciaReporteCiudadano(IdEvidenciaReporteCiudadano);
            response.Status = responseEvidenciaReporteCiudadano.Status;
            if (response.Status.Exito == 1)
            {
                EvidenciaReporteCiudadano = responseEvidenciaReporteCiudadano.Data;
                response = EliminarArchivo();
                if (response.Status.Exito == 1)
                {
                    response = EvidenciaReporteCiudadanoQuerys.DeleteEvidenciaReporteCiudadano(EvidenciaReporteCiudadano);
                }
            }

            return response;
        }

        private Response<object> EliminarArchivo()
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaEvidenciaReporteCiudadano + EvidenciaReporteCiudadano.IdVercionReporteCiudadano + "\\" + EvidenciaReporteCiudadano.Ruta;
            response = ServicioFicheros.ArchivoEliminar(ruta);

            return response;
        }
    }
}
