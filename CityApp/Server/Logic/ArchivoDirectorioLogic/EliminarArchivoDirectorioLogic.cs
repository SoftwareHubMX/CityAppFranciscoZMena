using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoDirectorioLogic
{
    public class EliminarArchivoDirectorioLogic
    {
        private ArchivoDirectorioQuerys ArchivoDirectorioQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private int IdArchivoDirectorio;
        private ArchivoDirectorio ArchivoDirectorio;

        public EliminarArchivoDirectorioLogic(CityAppContext cityAppContext, int idArchivoDirectorio)
        {
            ArchivoDirectorioQuerys = new ArchivoDirectorioQuerys(cityAppContext);

            IdArchivoDirectorio = idArchivoDirectorio;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            response = CargarArchivoDirectorio();
            if (response.Status.Exito == 1)
            {
                response = ArchivoDirectorioQuerys.DeletetArchivoDirectorio(ArchivoDirectorio);
                if (response.Status.Exito == 1)
                {
                    response = EliminarArchivo();
                }
            }

            return response;
        }

        private Response<object> CargarArchivoDirectorio()
        {
            Response<object> response = new Response<object>();

            Response<ArchivoDirectorio> responseArchivo = ArchivoDirectorioQuerys.SelecttArchivoDirectorio(IdArchivoDirectorio);
            response.Status = responseArchivo.Status;
            if (response.Status.Exito == 1)
            {
                ArchivoDirectorio = responseArchivo.Data;
            }

            return response;
        }

        private Response<object> EliminarArchivo()
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaMultimediaDirectorio + ArchivoDirectorio.IdDirectorio + "\\" + ArchivoDirectorio.Ruta;
            response = ServicioFicheros.ArchivoEliminar(ruta);

            return response;
        }
    }
}
