using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.HistoricoPredioLogic
{
    public class EliminarHistoricoPredioLogic
    {
        private HistoricoPredioQuerys HistoricoPredioQuerys;
        private ArchivoHistoricoPredioQuerys ArchivoHistoricoPredioQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private int IdHistoricoPredio = 0;

        public EliminarHistoricoPredioLogic(CityAppContext cityAppContext, int idHistoricoPredio)
        {
            HistoricoPredioQuerys = new HistoricoPredioQuerys(cityAppContext);
            ArchivoHistoricoPredioQuerys = new ArchivoHistoricoPredioQuerys(cityAppContext);

            IdHistoricoPredio = idHistoricoPredio;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<HistoricoPredio> responseHistorico = new Response<HistoricoPredio>();
            responseHistorico = HistoricoPredioQuerys.SelectHistoricoPredioIdHistoricoPredio(IdHistoricoPredio);
            response.Status = responseHistorico.Status;
            if(response.Status.Exito == 1)
            {
                
                Response<ArchivoHistoricoPredio> responseArchivo = new Response<ArchivoHistoricoPredio>();
                responseArchivo = ArchivoHistoricoPredioQuerys.SelectArchivoHistoricoPredioIdHistoricoPredioFirst(IdHistoricoPredio);
                if(responseArchivo.Status.Exito == 1)
                {
                    response = EliminarArchivoHistorico(responseArchivo.Data);
                    if (response.Status.Exito == 1)
                    {
                        response = HistoricoPredioQuerys.DeleteHistoricoPredio(responseHistorico.Data);
                    }
                }
            }

            return response;
        }

        public Response<object> EliminarArchivoHistorico(ArchivoHistoricoPredio archivoHistoricoPredio)
        {
            Response<object> response = new Response<object>();
            response = ArchivoHistoricoPredioQuerys.DeleteArchivoHistoricoPredio(archivoHistoricoPredio);
            if (response.Status.Exito == 1)
            {
                response = EliminarArchivo(archivoHistoricoPredio.Ruta);
            }

            return response;
        }

        private Response<object> EliminarArchivo(string rutaArchivo)
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaHistoricosPredios + rutaArchivo;
            response = ServicioFicheros.ArchivoEliminar(ruta);

            return response;
        }
    }
}
