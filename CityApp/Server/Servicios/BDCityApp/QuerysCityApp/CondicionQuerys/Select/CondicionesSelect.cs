using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CondicionQuerys.Select
{
    public class CondicionesSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Condicion> SelectCityApp = new SelectCityApp<Condicion>();

        public CondicionesSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Condicion>> SelectCondiciones()
        {
            Response<IEnumerable<Condicion>> response = new Response<IEnumerable<Condicion>>();

            try
            {
                response.Data = CityAppContext.Condiciones;

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
