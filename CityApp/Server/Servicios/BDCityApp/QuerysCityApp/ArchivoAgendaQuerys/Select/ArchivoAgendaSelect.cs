using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys.Select
{
    public class ArchivoAgendaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoAgenda> SelectCityApp = new SelectCityApp<ArchivoAgenda>();

        public ArchivoAgendaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<ArchivoAgenda> SelectArchivoAgendaIdArchivoAgenda(int idArchivoAgenda)
        {
            Response<ArchivoAgenda> response = new Response<ArchivoAgenda>();

            try
            {
                response.Data = CityAppContext.ArchivosAgenda.Where(d => d.IdArchivoAgenda == idArchivoAgenda).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<ArchivoAgenda> SelectArchivoAgendaIdAgendaPrincipal(int idAgenda)
        {
            Response<ArchivoAgenda> response = new Response<ArchivoAgenda>();

            try
            {
                response.Data = (from data in CityAppContext.ArchivosAgenda
                                 where data.IdAgenda == idAgenda
                                 && data.Principal == true
                                 select new ArchivoAgenda()
                                 {
                                     IdArchivoAgenda = data.IdAgenda,
                                     Ruta = data.Ruta,
                                     Formato = data.Formato,
                                     Principal = data.Principal,
                                     IdAgenda = data.IdAgenda,
                                     Agenda = null,
                                 }).First();


                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<ArchivoAgenda> SelectArchivoAgendaIdAgendaFirst(int idAgenda)
        {
            Response<ArchivoAgenda> response = new Response<ArchivoAgenda>();

            try
            {
                response.Data = (from data in CityAppContext.ArchivosAgenda
                                 where data.IdAgenda == idAgenda
                                 select new ArchivoAgenda()
                                 {
                                     IdArchivoAgenda = data.IdAgenda,
                                     Ruta = data.Ruta,
                                     Formato = data.Formato,
                                     Principal = data.Principal,
                                     IdAgenda = data.IdAgenda,
                                     Agenda = null,
                                 }).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
