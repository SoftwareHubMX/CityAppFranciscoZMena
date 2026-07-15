using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoLugarTuristicoLogic
{
    public class EliminarArchivoLugarTuristicoLogic
    {
        private ArchivoLugarTuristicoQuerys ArchivoLugarTuristicoQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private int IdArchivoLugarTuristico;
        private ArchivoLugarTuristico ArchivoLugarTuristico;

        public EliminarArchivoLugarTuristicoLogic(CityAppContext cityAppContext, int idArchivoLugarTuristico)
        {
            ArchivoLugarTuristicoQuerys = new ArchivoLugarTuristicoQuerys(cityAppContext);

            IdArchivoLugarTuristico = idArchivoLugarTuristico;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            response = CargarArchivoLugarTuristico();
            if (response.Status.Exito == 1)
            {
                response = ArchivoLugarTuristicoQuerys.DeleteArchivoLugarTuristico(ArchivoLugarTuristico);
                if (response.Status.Exito == 1)
                {
                    response = EliminarArchivo();
                }
            }

            return response;
        }

        private Response<object> CargarArchivoLugarTuristico()
        {
            Response<object> response = new Response<object>();

            Response<ArchivoLugarTuristico> responseArchivoLugarTuristico = ArchivoLugarTuristicoQuerys.SelectArchivoLugarTuristicoIdArchivoLugarTuristico(IdArchivoLugarTuristico);
            response.Status = responseArchivoLugarTuristico.Status;
            if (response.Status.Exito == 1)
            {
                ArchivoLugarTuristico = responseArchivoLugarTuristico.Data;
            }

            return response;
        }

        private Response<object> EliminarArchivo()
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaMultimediaTurismo + ArchivoLugarTuristico.IdLugarTuristico + "\\" + ArchivoLugarTuristico.Ruta;
            response = ServicioFicheros.ArchivoEliminar(ruta);

            return response;
        }
    }
}
