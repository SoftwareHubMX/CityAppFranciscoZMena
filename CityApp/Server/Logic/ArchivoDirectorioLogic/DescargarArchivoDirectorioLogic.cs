using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoDirectorioLogic
{
    public class DescargarArchivoDirectorioLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private string Archivo;
        private int IdDirectorio;

        public DescargarArchivoDirectorioLogic(string archivo, int idDirectorio)
        {
            Archivo = archivo;
            IdDirectorio = idDirectorio;
        }

        public Response<byte[]> Descargar()
        {
            Response<byte[]> response = new Response<byte[]>();

            string ruta = Rutas.RutaMultimediaDirectorio + IdDirectorio + "\\" + Archivo;
            response = ServicioFicheros.ArchivoLeer(ruta);

            return response;
        }
    }
}
