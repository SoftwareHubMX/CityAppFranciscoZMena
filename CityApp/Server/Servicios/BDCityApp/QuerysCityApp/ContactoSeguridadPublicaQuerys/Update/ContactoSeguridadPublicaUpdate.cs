using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys.Update
{
    public class ContactoSeguridadPublicaUpdate
    {
        private UpdateCityApp<ContactoSeguridadPublica> UpdateCityApp;

        public ContactoSeguridadPublicaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<ContactoSeguridadPublica>(cityAppContext);
        }

        public Response<object> UpdateContactoSeguridadPublica(ContactoSeguridadPublica ContactoSeguridadPublica)
        {
            return UpdateCityApp.Save(ContactoSeguridadPublica);
        }
    }
}
