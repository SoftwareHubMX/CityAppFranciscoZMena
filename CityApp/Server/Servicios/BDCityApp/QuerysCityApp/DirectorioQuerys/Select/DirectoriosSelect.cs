using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DirectorioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys.Select
{
    public class DirectoriosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Directorio> SelectCityApp = new SelectCityApp<Directorio>();

        private Paginado<Directorio> Paginado = new Paginado<Directorio>();

        public DirectoriosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Directorio>> SelectDirectorios()
        {
            Response<IEnumerable<Directorio>> response = new Response<IEnumerable<Directorio>>();

            try
            {
                response.Data = CityAppContext.Directorios;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<Directorio>> SelectDirectoriosFirltoDirectorio(FiltroDirectorio filtroDirectorio)
        {
            Response<IEnumerable<Directorio>> response = new Response<IEnumerable<Directorio>>();

            try
            {
                response.Data = CityAppContext.Directorios;
                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroDirectorio.MaximoElementos, filtroDirectorio.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }


    }
}
