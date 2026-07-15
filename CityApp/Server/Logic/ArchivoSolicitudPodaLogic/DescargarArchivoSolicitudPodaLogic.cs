using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoSolicitudPodaLogic
{
    public class DescargarArchivoSolicitudPodaLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private string Archivo;
        private int IdSolicitudPoda;

        public DescargarArchivoSolicitudPodaLogic(string archivo, int idSolicitudPoda)
        {
            Archivo = archivo;
            IdSolicitudPoda = idSolicitudPoda;
        }

        public Response<byte[]> Descargar()
        {
            Response<byte[]> response = new Response<byte[]>();

            string ruta = Rutas.RutaMultimediaSolicitudes + IdSolicitudPoda + "\\" + Archivo;
            response = ServicioFicheros.ArchivoLeer(ruta);

            return response;
        }
    }
}
