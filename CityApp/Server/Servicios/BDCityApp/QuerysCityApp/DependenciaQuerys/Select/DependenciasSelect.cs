using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DependenciaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys.Select
{
    public class DependenciasSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Dependencia> SelectCityApp = new SelectCityApp<Dependencia>();
        private Paginado<Dependencia> Paginado = new Paginado<Dependencia>();

        public DependenciasSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Dependencia>> SelectDependencias(int idSecretaria)
        {
            Response<IEnumerable<Dependencia>> response = new Response<IEnumerable<Dependencia>>();

            try
            {
                response.Data = CityAppContext.Dependencias.Where(d => d.IdSecretaria == idSecretaria);

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<Dependencia>> SelectSecretariasFirltoSecretaria(FiltroDependencia filtroDependencia)
        {
            Response<IEnumerable<Dependencia>> response = new Response<IEnumerable<Dependencia>>();

            try
            {
                response.Data = CityAppContext.Dependencias;
                if(filtroDependencia.IdSecretaria != 0)
                {
                    response.Data = response.Data.Where(d => d.IdSecretaria == filtroDependencia.IdSecretaria);
                }
                
                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroDependencia.MaximoElementos, filtroDependencia.Pagina);
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
