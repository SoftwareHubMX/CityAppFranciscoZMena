using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys.Select
{
    public class RutaRecoleccionSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<RutaRecoleccion> SelectCityApp = new SelectCityApp<RutaRecoleccion>();

        public RutaRecoleccionSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<RutaRecoleccion> SelectRutaRecoleccionIdRutaRecoleccion(int idRutaRecoleccion)
        {
            Response<RutaRecoleccion> response = new Response<RutaRecoleccion>();

            try
            {
                response.Data = CityAppContext.RutasRecoleccion.Where(d => d.IdRutaRecoleccion == idRutaRecoleccion).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<RutaRecoleccion> SelectLastIdRutaRecoleccion()
        {
            Response<RutaRecoleccion> response = new Response<RutaRecoleccion>();

            try
            {
                response.Data = CityAppContext.RutasRecoleccion.OrderBy(d => d.IdCuenta).LastOrDefault();

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
