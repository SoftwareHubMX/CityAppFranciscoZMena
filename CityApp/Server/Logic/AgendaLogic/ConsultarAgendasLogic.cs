using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AgendaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AgendaLogic
{
    public class ConsultarAgendasLogic
    {
        private AgendaQuerys AgendaQuerys;
        private ArchivoAgendaQuerys ArchivoAgendaQuerys;

        private FiltroAgenda FiltroAgendas;
        private List<Agenda> Agendas;

        public ConsultarAgendasLogic(CityAppContext cityAppContetx, FiltroAgenda filtroAgendas)
        {
            AgendaQuerys = new AgendaQuerys(cityAppContetx);
            ArchivoAgendaQuerys = new ArchivoAgendaQuerys(cityAppContetx);

            FiltroAgendas = filtroAgendas;
        }

        public Response<List<Agenda>> Consultar()
        {
            Response<List<Agenda>> response = new Response<List<Agenda>>();

            Response<IEnumerable<Agenda>> responseAgendas = AgendaQuerys.SelectAgendasFiltroAgendas(FiltroAgendas);
            response.Status = responseAgendas.Status;
            if (response.Status.Exito == 1)
            {
                Agendas = responseAgendas.Data.ToList();
                Response<object> responseCargarListas = CargarListas();
                response.Status = responseCargarListas.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = Agendas;
                    response.Info = responseAgendas.Info;
                }
            }

            return response;
        }

        private Response<object> CargarListas()
        {
            Response<object> response = new Response<object>();

            for (int i = 0; i < Agendas.Count; i++)
            {
                if (Agendas[i].Texto.Length > 150)
                {
                    Agendas[i].Texto = Agendas[i].Texto.Substring(0, 150) + "...";
                }

                Response<ArchivoAgenda> responseArchivoAgenda = ArchivoAgendaQuerys.SelectArchivoAgendaIdAgendaPrincipal(Agendas[i].IdAgenda);
                response.Status = responseArchivoAgenda.Status;
                if (response.Status.Exito == 1)
                {
                    Agendas[i].ArchivosAgenda = new List<ArchivoAgenda>() { responseArchivoAgenda.Data };
                }
                else if (response.Status.Exito == 2)
                {
                    responseArchivoAgenda = ArchivoAgendaQuerys.SelectArchivoAgendaIdAgendaFirst(Agendas[i].IdAgenda);
                    response.Status = responseArchivoAgenda.Status;
                    if (response.Status.Exito == 1)
                    {
                        Agendas[i].ArchivosAgenda = new List<ArchivoAgenda>() { responseArchivoAgenda.Data };
                    }
                    else if (response.Status.Exito == 2)
                    {
                        response.Status.Exito = 1;
                    }
                    else if (response.Status.Exito == 0)
                    {
                        i = Agendas.Count;
                    }
                }
                else if (response.Status.Exito == 0)
                {
                    i = Agendas.Count;
                }
            }

            return response;
        }
    }
}
