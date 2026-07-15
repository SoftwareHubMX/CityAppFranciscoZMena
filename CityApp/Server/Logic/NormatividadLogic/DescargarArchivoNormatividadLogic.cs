using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NormatividadLogic
{
    public class DescargarArchivoNormatividadLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private string Archivo;

        public DescargarArchivoNormatividadLogic(string archivo)
        {
            Archivo = archivo;
        }

        public Response<byte[]> Descargar()
        {
            Response<byte[]> response = new Response<byte[]>();

            string ruta = Rutas.RutaMultimediaNormatividades + "\\" + Archivo;
            response = ServicioFicheros.ArchivoLeer(ruta);

            return response;
        }
    }
}
