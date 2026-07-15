using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoAgendaLogic
{
    public class EliminarArchivoAgendaLogic
    {
        private ArchivoAgendaQuerys ArchivoAgendaQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private int IdArchivoAgenda;
        private ArchivoAgenda ArchivoAgenda;

        public EliminarArchivoAgendaLogic(CityAppContext cityAppContext, int idArchivoAgenda)
        {
            ArchivoAgendaQuerys = new ArchivoAgendaQuerys(cityAppContext);

            IdArchivoAgenda = idArchivoAgenda;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            response = CargarArchivoAgenda();
            if (response.Status.Exito == 1)
            {
                response = ArchivoAgendaQuerys.DeleteArchivoAgenda(ArchivoAgenda);
                if (response.Status.Exito == 1)
                {
                    response = EliminarArchivo();
                }
            }

            return response;
        }

        private Response<object> CargarArchivoAgenda()
        {
            Response<object> response = new Response<object>();

            Response<ArchivoAgenda> responseArchivoAgenda = ArchivoAgendaQuerys.SelectArchivoAgendaIdArchivoAgenda(IdArchivoAgenda);
            response.Status = responseArchivoAgenda.Status;
            if (response.Status.Exito == 1)
            {
                ArchivoAgenda = responseArchivoAgenda.Data;
            }

            return response;
        }

        private Response<object> EliminarArchivo()
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaMultimediaAgendas + ArchivoAgenda.IdAgenda + "\\" + ArchivoAgenda.Ruta;
            response = ServicioFicheros.ArchivoEliminar(ruta);

            return response;
        }
    }
}
