using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSolicitudPodaQuerys.Select
{
    public class ArchivosSolicitudPodaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoSolicitidPoda> SelectCityApp = new SelectCityApp<ArchivoSolicitidPoda>();
        private Paginado<ArchivoSolicitidPoda> Paginado = new Paginado<ArchivoSolicitidPoda>();

        public ArchivosSolicitudPodaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<ArchivoSolicitidPoda>> SelectArchivoSolicitudPodaIdSolicitudPoda(int idSolicitudPoda)
        {
            Response<IEnumerable<ArchivoSolicitidPoda>> response = new Response<IEnumerable<ArchivoSolicitidPoda>>();

            try
            {
                response.Data = from data in CityAppContext.ArchivosSolicitidPoda
                                where data.IdSolicitudPoda == idSolicitudPoda
                                select new ArchivoSolicitidPoda()
                                {
                                    IdArchivoSolicitudPoda = data.IdArchivoSolicitudPoda,
                                    Ruta = data.Ruta,
                                    Formato = data.Formato,
                                    Principal = data.Principal,
                                    IdSolicitudPoda = data.IdSolicitudPoda,
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
