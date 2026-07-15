using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys.Select
{
    public class IdColoniaRutaRecoleccionSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdColoniaRutaRecoleccionSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<int> SelectColoniaRutaRecoleccionIdRutaRecoleccion(int idColonia, int idRutaRecoleccion)
        {
            Response<int> response = new Response<int>();

            try
            {
                response.Data = (from data in CityAppContext.ColoniasRutaRecoleccion
                                 orderby data.IdColoniaRutaRecoleccion
                                 where data.IdColonia == idColonia
                                 && data.IdRutaRecoleccion == idRutaRecoleccion
                                 select data.IdColoniaRutaRecoleccion).LastOrDefault();


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
