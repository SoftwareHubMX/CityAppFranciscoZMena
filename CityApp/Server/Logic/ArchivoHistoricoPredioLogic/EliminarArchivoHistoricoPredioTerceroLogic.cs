using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoHistoricoPredioLogic
{
    public class EliminarArchivoHistoricoPredioTerceroLogic
    {
        private ArchivoHistoricoPredioQuerys ArchivoHistoricoPredioQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();
        private ArchivoHistoricoPredio ArchivoHistoricoPredio = new ArchivoHistoricoPredio();

        public EliminarArchivoHistoricoPredioTerceroLogic(CityAppContext cityAppContext)
        {
            ArchivoHistoricoPredioQuerys = new ArchivoHistoricoPredioQuerys(cityAppContext);
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            response = CargarArchivoHistoricoPredio();
            if (response.Status.Exito == 1)
            {
                response = ArchivoHistoricoPredioQuerys.DeleteArchivoHistoricoPredio(ArchivoHistoricoPredio);
                if (response.Status.Exito == 1)
                {
                    response = EliminarArchivo();
                }
            }

            return response;
        }

        private Response<object> CargarArchivoHistoricoPredio()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoHistoricoPredio>> responseArchivoHistoricoPredio = ArchivoHistoricoPredioQuerys.SelectArchivosHistoricosPredios();
            response.Status = responseArchivoHistoricoPredio.Status;
            if (response.Status.Exito == 1)
            {
                List<ArchivoHistoricoPredio> archivos = responseArchivoHistoricoPredio.Data.ToList();
                if(archivos.Count > 2)
                {
                    ArchivoHistoricoPredio = archivos[2];
                }
                else
                {
                    response.Status.Mensaje = "Eliminacion de archivo no necesaria";
                    response.Status.Exito = 2;
                }
            }

            return response;
        }

        private Response<object> EliminarArchivo()
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaHistoricosPredios + ArchivoHistoricoPredio.Ruta;
            response = ServicioFicheros.ArchivoEliminar(ruta);

            return response;
        }
    }
}
