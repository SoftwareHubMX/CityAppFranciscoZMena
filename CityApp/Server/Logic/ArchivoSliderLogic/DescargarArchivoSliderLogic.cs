using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoSliderLogic
{
    public class DescargarArchivoSliderLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private string Archivo;
        private int IdSlider;

        public DescargarArchivoSliderLogic(string archivo, int idSlider)
        {
            Archivo = archivo;
            IdSlider = idSlider;
        }

        public Response<byte[]> Descargar()
        {
            Response<byte[]> response = new Response<byte[]>();

            string ruta = Rutas.RutaMultimediaSliders + IdSlider + "\\" + Archivo;
            response = ServicioFicheros.ArchivoLeer(ruta);

            return response;
        }
    }
}
