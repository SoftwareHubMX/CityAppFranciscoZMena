using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys.Select
{
    public class ColoniaRutaRecoleccionSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ColoniaRutaRecoleccion> SelectCityApp = new SelectCityApp<ColoniaRutaRecoleccion>();

        public ColoniaRutaRecoleccionSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<ColoniaRutaRecoleccion> SelectColoniaRutaRecoleccionIdColoniaRutaRecoleccion(int idColonia, int idRutaRecoleccion)
        {
            Response<ColoniaRutaRecoleccion> response = new Response<ColoniaRutaRecoleccion>();

            try
            {
                response.Data = CityAppContext.ColoniasRutaRecoleccion.Where(d => d.IdColonia == idColonia && d.IdRutaRecoleccion == idRutaRecoleccion).LastOrDefault();
                

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
