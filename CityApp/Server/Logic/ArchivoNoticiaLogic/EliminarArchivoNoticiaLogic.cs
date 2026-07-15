using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoNoticiaLogic
{
    public class EliminarArchivoNoticiaLogic
    {
        private ArchivoNoticiaQuerys ArchivoNoticiaQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private int IdArchivoNoticia;
        private ArchivoNoticia ArchivoNoticia;

        public EliminarArchivoNoticiaLogic(CityAppContext cityAppContext, int idArchivoNoticia)
        {
            ArchivoNoticiaQuerys = new ArchivoNoticiaQuerys(cityAppContext);

            IdArchivoNoticia = idArchivoNoticia;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            response = CargarArchivoNoticia();
            if (response.Status.Exito == 1)
            {
                response = ArchivoNoticiaQuerys.DeleteArchivoNoticia(ArchivoNoticia);
                if (response.Status.Exito == 1)
                {
                    response = EliminarArchivo();
                }
            }

            return response;
        }

        private Response<object> CargarArchivoNoticia()
        {
            Response<object> response = new Response<object>();

            Response<ArchivoNoticia> responseArchivoNoticia = ArchivoNoticiaQuerys.SelectArchivoNoticiaIdArchivoNoticia(IdArchivoNoticia);
            response.Status = responseArchivoNoticia.Status;
            if (response.Status.Exito == 1)
            {
                ArchivoNoticia = responseArchivoNoticia.Data;
            }

            return response;
        }

        private Response<object> EliminarArchivo()
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaMultimediaNoticias + ArchivoNoticia.IdNoticia + "\\" + ArchivoNoticia.Ruta;
            response = ServicioFicheros.ArchivoEliminar(ruta);

            return response;
        }
    }
}
