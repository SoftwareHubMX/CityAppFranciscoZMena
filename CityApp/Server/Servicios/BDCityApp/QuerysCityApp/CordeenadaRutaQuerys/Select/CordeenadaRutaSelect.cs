using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CordeenadaRutaQuerys.Select
{
    public class CordeenadaRutaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<CordeenadaRuta> SelectCityApp = new SelectCityApp<CordeenadaRuta>();

        public CordeenadaRutaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<CordeenadaRuta> SelectCorddenadaRuta(int idRutaRecoleccion)
        {
            Response<CordeenadaRuta> response = new Response<CordeenadaRuta>();

            try
            {
                response.Data = CityAppContext.CordeenadasRuta.Where(d => d.IdRutaRecoleccion == idRutaRecoleccion).First();
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
