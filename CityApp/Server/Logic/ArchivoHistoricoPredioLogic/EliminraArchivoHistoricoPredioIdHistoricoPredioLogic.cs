using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoHistoricoPredioLogic
{
    public class EliminraArchivoHistoricoPredioIdHistoricoPredioLogic
    {
        private ArchivoHistoricoPredioQuerys ArchivoHistoricoPredioQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private int IdHistoricoPredio;
        private ArchivoHistoricoPredio ArchivoHistoricoPredio;

        public EliminraArchivoHistoricoPredioIdHistoricoPredioLogic(CityAppContext cityAppContext, int idHistoricoPredio)
        {
            ArchivoHistoricoPredioQuerys = new ArchivoHistoricoPredioQuerys(cityAppContext);

            IdHistoricoPredio = idHistoricoPredio;
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

            Response<ArchivoHistoricoPredio> responseArchivoHistoricoPredio = ArchivoHistoricoPredioQuerys.SelectArchivoHistoricoPredioIdHistoricoPredioFirst(IdHistoricoPredio);
            response.Status = responseArchivoHistoricoPredio.Status;
            if (response.Status.Exito == 1)
            {
                ArchivoHistoricoPredio = responseArchivoHistoricoPredio.Data;
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
