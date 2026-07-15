using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoAnuncioLogic
{
    public class EliminarArchivoAnuncioLogic
    {
        private ArchivoAnuncioQuerys ArchivoAnuncioQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private int IdArchivoAnuncio;
        private ArchivoAnuncio ArchivoAnuncio;

        public EliminarArchivoAnuncioLogic(CityAppContext cityAppContext, int idArchivoAnuncio)
        {
            ArchivoAnuncioQuerys = new ArchivoAnuncioQuerys(cityAppContext);

            IdArchivoAnuncio = idArchivoAnuncio;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            response = CargarArchivoAnuncio();
            if (response.Status.Exito == 1)
            {
                response = ArchivoAnuncioQuerys.DeleteArchivoAnuncio(ArchivoAnuncio);
                if (response.Status.Exito == 1)
                {
                    response = EliminarArchivo();
                }
            }

            return response;
        }

        private Response<object> CargarArchivoAnuncio()
        {
            Response<object> response = new Response<object>();

            Response<ArchivoAnuncio> responseArchivo = ArchivoAnuncioQuerys.SelectArchivoAnuncio(IdArchivoAnuncio);
            response.Status = responseArchivo.Status;
            if (response.Status.Exito == 1)
            {
                ArchivoAnuncio = responseArchivo.Data;
            }

            return response;
        }

        private Response<object> EliminarArchivo()
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaMultimediaArchivoAnuncio + ArchivoAnuncio.IdAnuncio + "\\" + ArchivoAnuncio.Ruta;
            response = ServicioFicheros.ArchivoEliminar(ruta);

            return response;
        }
    }
}
