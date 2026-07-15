using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.GiroQuerys.Select
{
    public class GirosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Giro> SelectCityApp = new SelectCityApp<Giro>();

        public GirosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Giro>> SelectGiros()
        {
            Response<IEnumerable<Giro>> response = new Response<IEnumerable<Giro>>();

            try
            {
                response.Data = CityAppContext.Giros;

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
