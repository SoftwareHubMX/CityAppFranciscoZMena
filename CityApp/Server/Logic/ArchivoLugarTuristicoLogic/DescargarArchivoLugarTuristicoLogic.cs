using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoLugarTuristicoLogic
{
    public class DescargarArchivoLugarTuristicoLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private string Archivo;
        private int IdLugarTuristico;

        public DescargarArchivoLugarTuristicoLogic(string archivo, int idLugarTuristico)
        {
            Archivo = archivo;
            IdLugarTuristico = idLugarTuristico;
        }

        public Response<byte[]> Descargar()
        {
            Response<byte[]> response = new Response<byte[]>();

            string ruta = Rutas.RutaMultimediaTurismo + IdLugarTuristico + "\\" + Archivo;
            response = ServicioFicheros.ArchivoLeer(ruta);

            return response;
        }
    }
}
