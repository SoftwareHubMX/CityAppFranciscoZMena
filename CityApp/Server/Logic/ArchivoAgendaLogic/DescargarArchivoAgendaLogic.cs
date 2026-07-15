using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoAgendaLogic
{
    public class DescargarArchivoAgendaLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private string Archivo;
        private int IdAgenda;

        public DescargarArchivoAgendaLogic(string archivo, int idAgenda)
        {
            Archivo = archivo;
            IdAgenda = idAgenda;
        }

        public Response<byte[]> Descargar()
        {
            Response<byte[]> response = new Response<byte[]>();

            string ruta = Rutas.RutaMultimediaAgendas + IdAgenda + "\\" + Archivo;
            response = ServicioFicheros.ArchivoLeer(ruta);

            return response;
        }
    }
}
