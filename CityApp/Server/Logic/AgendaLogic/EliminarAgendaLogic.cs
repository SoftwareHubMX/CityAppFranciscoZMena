using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AgendaLogic
{
    public class EliminarAgendaLogic
    {
        private AgendaQuerys AgendaQuerys;
        private ArchivoAgendaQuerys ArchivoAgendaQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private Agenda Agenda;

        public EliminarAgendaLogic(CityAppContext cityAppContext, int idAgenda)
        {
            AgendaQuerys = new AgendaQuerys(cityAppContext);
            ArchivoAgendaQuerys = new ArchivoAgendaQuerys(cityAppContext);

            Agenda = new Agenda()
            {
                IdAgenda = idAgenda,
            };
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Agenda> responseNotica = AgendaQuerys.SelectAgendaIdAgenda(Agenda.IdAgenda);
            response.Status = responseNotica.Status;
            if (response.Status.Exito == 1)
            {
                Agenda = responseNotica.Data;
                response = EliminarListaArchivos();
                if (response.Status.Exito == 1)
                {
                    response = AgendaQuerys.DeleteAgenda(responseNotica.Data);
                }
            }

            return response;
        }

        private Response<object> EliminarListaArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoAgenda>> responseArchivosAgenda = ArchivoAgendaQuerys.SelectArchivosAgendaIdAgenda(Agenda.IdAgenda);
            response.Status = responseArchivosAgenda.Status;
            if (response.Status.Exito == 1)
            {
                Agenda.ArchivosAgenda = responseArchivosAgenda.Data.ToList();
                response = EliminarFicheros();
                if (response.Status.Exito == 1)
                {
                    response = ArchivoAgendaQuerys.DeleteArchivosAgenda(responseArchivosAgenda.Data);
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

            foreach (var archivo in Agenda.ArchivosAgenda)
            {
                string ruta = Rutas.RutaMultimediaAgendas + Agenda.IdAgenda + "\\" + archivo.Ruta;
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
