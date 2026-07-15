using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys.Select
{
    public class ContactoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Contacto> SelectCityApp = new SelectCityApp<Contacto>();

        public ContactoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Contacto> SelectContactoIdCuenta(int idCuenta)
        {
            Response<Contacto> response = new Response<Contacto>();

            try
            {
                response.Data = CityAppContext.Contactos.Where(d => d.IdCuenta == idCuenta).First();

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
