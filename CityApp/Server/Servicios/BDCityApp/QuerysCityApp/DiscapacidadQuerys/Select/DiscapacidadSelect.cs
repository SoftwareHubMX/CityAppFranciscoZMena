using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiscapacidadQuerys.Select
{
    public class DiscapacidadSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Discapacidad> SelectCityApp = new SelectCityApp<Discapacidad>();

        public DiscapacidadSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Discapacidad> SelectDiscapacidad(int idDiscapacidad)
        {
            Response<Discapacidad> response = new Response<Discapacidad>();

            try
            {
                response.Data = CityAppContext.Discapacidades.Where(d => d.IdDicapacidad == idDiscapacidad).First();

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
