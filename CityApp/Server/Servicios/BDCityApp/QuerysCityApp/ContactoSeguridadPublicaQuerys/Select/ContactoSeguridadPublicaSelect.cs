using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys.Select
{
    public class ContactoSeguridadPublicaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ContactoSeguridadPublica> SelectCityApp = new SelectCityApp<ContactoSeguridadPublica>();

        private Paginado<ContactoSeguridadPublica> Paginado = new Paginado<ContactoSeguridadPublica>();

        public ContactoSeguridadPublicaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<ContactoSeguridadPublica> SelectContactoSeguridadPublica(int idContactoSeguridadPublica)
        {
            Response<ContactoSeguridadPublica> response = new Response<ContactoSeguridadPublica>();

            try
            {
                response.Data = CityAppContext.ContactosSeguridadPublica.Where(d =>
                d.IdContactoSeguridadPublica == idContactoSeguridadPublica).FirstOrDefault();

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
