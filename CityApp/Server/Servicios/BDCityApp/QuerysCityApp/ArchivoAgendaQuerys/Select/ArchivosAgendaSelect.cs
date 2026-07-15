using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys.Select
{
    public class ArchivosAgendaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoAgenda> SelectCityApp = new SelectCityApp<ArchivoAgenda>();

        public ArchivosAgendaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<ArchivoAgenda>> SelectArchivosAgendaIdAgenda(int idAgenda)
        {
            Response<IEnumerable<ArchivoAgenda>> response = new Response<IEnumerable<ArchivoAgenda>>();

            try
            {
                response.Data = from data in CityAppContext.ArchivosAgenda
                                where data.IdAgenda == idAgenda
                                select new ArchivoAgenda()
                                {
                                    IdArchivoAgenda = data.IdArchivoAgenda,
                                    Ruta = data.Ruta,
                                    Formato = data.Formato,
                                    Principal = data.Principal,
                                    IdAgenda = data.IdAgenda
                                };

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
