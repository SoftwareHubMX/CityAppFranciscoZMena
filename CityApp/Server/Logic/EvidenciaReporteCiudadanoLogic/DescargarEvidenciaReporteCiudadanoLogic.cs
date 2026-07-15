using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.EvidenciaReporteCiudadanoLogic
{
    public class DescargarEvidenciaReporteCiudadanoLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private int IdVercionReporteCiudadano;
        private string Archivo;

        public DescargarEvidenciaReporteCiudadanoLogic(int idVercionReporteCiudadano, string archivo)
        {
            IdVercionReporteCiudadano = idVercionReporteCiudadano;
            Archivo = archivo;
        }

        public Response<byte[]> Descargar()
        {
            Response<byte[]> response = new Response<byte[]>();

            string ruta = Rutas.RutaEvidenciaReporteCiudadano + IdVercionReporteCiudadano + "\\" + Archivo;
            response = ServicioFicheros.ArchivoLeer(ruta);

            return response;
        }
    }
}
