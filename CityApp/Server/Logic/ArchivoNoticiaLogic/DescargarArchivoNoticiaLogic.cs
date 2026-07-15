using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoNoticiaLogic
{
    public class DescargarArchivoNoticiaLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private string Archivo;
        private int IdNoticia;

        public DescargarArchivoNoticiaLogic(string archivo, int idNoticia)
        {
            Archivo = archivo;
            IdNoticia = idNoticia;
        }

        public Response<byte[]> Descargar()
        {
            Response<byte[]> response = new Response<byte[]>();

            string ruta = Rutas.RutaMultimediaNoticias + IdNoticia + "\\" + Archivo;
            response = ServicioFicheros.ArchivoLeer(ruta);

            return response;
        }
    }
}
