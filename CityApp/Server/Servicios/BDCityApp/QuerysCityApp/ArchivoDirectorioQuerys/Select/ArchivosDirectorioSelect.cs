using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys.Select
{
    public class ArchivosDirectorioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoDirectorio> SelectCityApp = new SelectCityApp<ArchivoDirectorio>();

        public ArchivosDirectorioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<ArchivoDirectorio>> SelectArchivosDirectorioIdDirectorio(int idDirectorio)
        {
            Response<IEnumerable<ArchivoDirectorio>> response = new Response<IEnumerable<ArchivoDirectorio>>();

            try
            {
                response.Data = from data in CityAppContext.ArchivosDirectorio
                                where data.IdDirectorio == idDirectorio
                                select new ArchivoDirectorio()
                                {
                                    IdArchivoDirectorio = data.IdArchivoDirectorio,
                                    Ruta = data.Ruta,
                                    Formato = data.Formato,
                                    Principal = data.Principal,
                                    IdDirectorio = data.IdDirectorio
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
