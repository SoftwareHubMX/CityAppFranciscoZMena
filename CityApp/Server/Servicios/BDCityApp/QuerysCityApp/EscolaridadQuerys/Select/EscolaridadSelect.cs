using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EscolaridadQuerys.Select
{
    public class EscolaridadSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Escolaridad> SelectCityApp = new SelectCityApp<Escolaridad>();

        public EscolaridadSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Escolaridad> SelectEscolaridad(int idEscolaridad)
        {
            Response<Escolaridad> response = new Response<Escolaridad>();

            try
            {
                response.Data = CityAppContext.Escolaridades.Where(d => d.IdEscolaridad == idEscolaridad).First();

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
