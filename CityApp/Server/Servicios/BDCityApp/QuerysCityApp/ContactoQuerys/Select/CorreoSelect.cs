using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys.Select
{
    public class CorreoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<string> SelectCityApp = new SelectCityApp<string>();

        public CorreoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<string> SelectCorreoIdCuenta(int idCuenta)
        {
            Response<string> response = new Response<string>();

            try
            {
                response.Data = CityAppContext.Contactos.Where(d => d.IdCuenta == idCuenta).First().Correo;

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<string> SelectCorreoCorreo(string correo)
        {
            Response<string> response = new Response<string>();

            try
            {
                response.Data = CityAppContext.Contactos.Where(d => d.Correo == correo).First().Correo;

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
