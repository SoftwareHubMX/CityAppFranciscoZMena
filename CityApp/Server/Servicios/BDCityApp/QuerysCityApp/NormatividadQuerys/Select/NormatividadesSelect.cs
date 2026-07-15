using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys.Select
{
    public class NormatividadesSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Normatividad> SelectCityApp = new SelectCityApp<Normatividad>();

        private Paginado<Normatividad> Paginado = new Paginado<Normatividad>();

        public NormatividadesSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Normatividad>> SelectNormatividades()
        {
            Response<IEnumerable<Normatividad>> response = new Response<IEnumerable<Normatividad>>();

            try
            {
                response.Data = CityAppContext.Normatividades;

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
