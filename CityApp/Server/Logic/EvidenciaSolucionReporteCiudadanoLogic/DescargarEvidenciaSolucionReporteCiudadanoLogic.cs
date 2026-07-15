using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.EvidenciaSolucionReporteCiudadanoLogic
{
    public class DescargarEvidenciaSolucionReporteCiudadanoLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private int IdReporteCiudadano;
        private string Archivo;

        public DescargarEvidenciaSolucionReporteCiudadanoLogic(int idReporteCiudadano, string archivo)
        {
            IdReporteCiudadano = idReporteCiudadano;
            Archivo = archivo;
        }

        public Response<byte[]> Descargar()
        {
            Response<byte[]> response = new Response<byte[]>();

            string ruta = Rutas.RutaEvidenciaSolucionReporteCiudadano + IdReporteCiudadano + "\\" + Archivo;
            response = ServicioFicheros.ArchivoLeer(ruta);

            return response;
        }
    }
}
