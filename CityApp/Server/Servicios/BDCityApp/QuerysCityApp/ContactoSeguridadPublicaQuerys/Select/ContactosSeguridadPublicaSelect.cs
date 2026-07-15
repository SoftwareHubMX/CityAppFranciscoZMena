using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys.Select
{
    public class ContactosSeguridadPublicaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ContactoSeguridadPublica> SelectCityApp = new SelectCityApp<ContactoSeguridadPublica>();

        private Paginado<ContactoSeguridadPublica> Paginado = new Paginado<ContactoSeguridadPublica>();

        public ContactosSeguridadPublicaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<ContactoSeguridadPublica>> SelectContactosSeguridadPublica()
        {
            Response<IEnumerable<ContactoSeguridadPublica>> response = new Response<IEnumerable<ContactoSeguridadPublica>>();

            try
            {
                response.Data = CityAppContext.ContactosSeguridadPublica;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
