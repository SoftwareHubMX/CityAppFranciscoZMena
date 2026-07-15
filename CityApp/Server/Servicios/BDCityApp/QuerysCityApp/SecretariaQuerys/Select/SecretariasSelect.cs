using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SecretariaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys.Select
{
    public class SecretariasSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Secretaria> SelectCityApp = new SelectCityApp<Secretaria>();
        private Paginado<Secretaria> Paginado = new Paginado<Secretaria>();

        public SecretariasSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Secretaria>> SelectSecretarias()
        {
            Response<IEnumerable<Secretaria>> response = new Response<IEnumerable<Secretaria>>();

            try
            {
                response.Data = CityAppContext.Secretarias;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<Secretaria>> SelectSecretariasFirltoSecretaria(FiltroSecretaria filtroSecretaria)
        {
            Response<IEnumerable<Secretaria>> response = new Response<IEnumerable<Secretaria>>();

            try
            {
                response.Data = CityAppContext.Secretarias;              
                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroSecretaria.MaximoElementos, filtroSecretaria.Pagina);
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
