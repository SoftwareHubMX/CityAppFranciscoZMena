using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NormatividadLogic
{
    public class EliminarArchivoNormatividadLogic
    {
        private ServicioFicheros ServicioFicheros = new ServicioFicheros();
        private string NombreArchivo = "";

        public EliminarArchivoNormatividadLogic(CityAppContext cityAppContext, string nombreArchivo)
        {
            NombreArchivo = nombreArchivo;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();
            response = EliminarArchivo();

            return response;
        }

        private Response<object> EliminarArchivo()
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaMultimediaNormatividades  + "\\" + NombreArchivo;
            response = ServicioFicheros.ArchivoEliminar(ruta);
            if(response.Status.Exito == 1)
            {
                string rutaPublica = Rutas.RutaMultimediaNormatividadesPublic + "\\" + NombreArchivo;
                response = ServicioFicheros.ArchivoEliminar(rutaPublica);
            }

            return response;
        }
    }
}
