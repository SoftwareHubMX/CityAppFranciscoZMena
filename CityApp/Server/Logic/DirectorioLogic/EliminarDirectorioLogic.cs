using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DirectorioLogic
{
    public class EliminarDirectorioLogic
    {
        private DirectorioQuerys DirectorioQuerys;
        private ArchivoDirectorioQuerys ArchivoDirectorioQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private Directorio Directorio;

        public EliminarDirectorioLogic(CityAppContext cityAppContext, int idDirectorio)
        {
            DirectorioQuerys = new DirectorioQuerys(cityAppContext);
            ArchivoDirectorioQuerys = new ArchivoDirectorioQuerys(cityAppContext);

            Directorio = new Directorio()
            {
                IdDirectorio = idDirectorio,
            };
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Directorio> responseArchivosDirectorio = DirectorioQuerys.SelectDirectorioIdDirectorio(Directorio.IdDirectorio);
            response.Status = responseArchivosDirectorio.Status;
            if (response.Status.Exito == 1)
            {
                Directorio = responseArchivosDirectorio.Data;
                response = EliminarListaArchivos();
                if (response.Status.Exito == 1)
                {
                    response = DirectorioQuerys.DeletetDirectorio(responseArchivosDirectorio.Data);
                }
            }

            return response;
        }

        private Response<object> EliminarListaArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoDirectorio>> responseArchivosDirectorio = ArchivoDirectorioQuerys.SelectArchivosDirectorioIdDirectorio(Directorio.IdDirectorio);
            response.Status = responseArchivosDirectorio.Status;
            if (response.Status.Exito == 1)
            {
                Directorio.ArchivosDirectorio = responseArchivosDirectorio.Data.ToList();
                response = EliminarFicheros();
                if (response.Status.Exito == 1)
                {
                    response = ArchivoDirectorioQuerys.DeleteArchivosDirectorio(responseArchivosDirectorio.Data);
                }
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }

        private Response<object> EliminarFicheros()
        {
            Response<object> response = new Response<object>();

            foreach (var archivo in Directorio.ArchivosDirectorio)
            {
                string ruta = Rutas.RutaMultimediaDirectorio + Directorio.IdDirectorio + "\\" + archivo.Ruta;
                response = ServicioFicheros.ArchivoEliminar(ruta);
                if (response.Status.Exito != 1)
                {
                    break;
                }
            }

            return response;
        }
    }
}
