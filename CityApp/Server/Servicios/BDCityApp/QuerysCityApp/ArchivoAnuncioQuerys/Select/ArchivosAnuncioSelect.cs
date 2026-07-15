using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys.Select
{
    public class ArchivosAnuncioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoAnuncio> SelectCityApp = new SelectCityApp<ArchivoAnuncio>();
        private Paginado<ArchivoAnuncio> Paginado = new Paginado<ArchivoAnuncio>();

        public ArchivosAnuncioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<ArchivoAnuncio>> SelectArchivoAnuncioIdAnuncio(int idAnuncio)
        {
            Response<IEnumerable<ArchivoAnuncio>> response = new Response<IEnumerable<ArchivoAnuncio>>();

            try
            {
                response.Data = from data in CityAppContext.ArchivosAnuncio
                                where data.IdAnuncio == idAnuncio
                                select new ArchivoAnuncio()
                                {
                                    IdArchivoAnuncio = data.IdArchivoAnuncio,
                                    Ruta = data.Ruta,
                                    Formato = data.Formato,
                                    Principal = data.Principal,
                                    IdAnuncio = data.IdAnuncio,
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
