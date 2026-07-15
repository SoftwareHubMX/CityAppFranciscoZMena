using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoHistoricoPredioLogic
{
    public class DescargarArchivoHistoricoPredioLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private string Archivo;
        private int IdHistoricoPredio;

        public DescargarArchivoHistoricoPredioLogic(string archivo, int idHistoricoPredio)
        {
            Archivo = archivo;
            IdHistoricoPredio = idHistoricoPredio;
        }

        public Response<byte[]> Descargar()
        {
            Response<byte[]> response = new Response<byte[]>();

            string ruta = Rutas.RutaHistoricosPredios + Archivo;
            response = ServicioFicheros.ArchivoLeer(ruta);

            return response;
        }
    }
}
