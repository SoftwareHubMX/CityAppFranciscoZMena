using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoAnuncioLogic
{
    public class DescargarArchivoAnuncioLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private string Archivo;
        private int IdAnuncio;

        public DescargarArchivoAnuncioLogic(string archivo, int idAnuncio)
        {
            Archivo = archivo;
            IdAnuncio = idAnuncio;
        }

        public Response<byte[]> Descargar()
        {
            Response<byte[]> response = new Response<byte[]>();

            string ruta = Rutas.RutaMultimediaArchivoAnuncio + IdAnuncio + "\\" + Archivo;
            response = ServicioFicheros.ArchivoLeer(ruta);

            return response;
        }
    }
}
