using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CondicionQuerys.Select
{
    public class CondicionSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Condicion> SelectCityApp = new SelectCityApp<Condicion>();

        public CondicionSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Condicion> SelectCondicion(int idCondicion)
        {
            Response<Condicion> response = new Response<Condicion>();

            try
            {
                response.Data = CityAppContext.Condiciones.Where(d => d.IdCondicion == idCondicion).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
