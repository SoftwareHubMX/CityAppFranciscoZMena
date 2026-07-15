using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys.Delete
{
    public class ContactoSeguridadPublicaDelete
    {
        private DeleteCityApp<ContactoSeguridadPublica> DeleteCityApp;

        public ContactoSeguridadPublicaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ContactoSeguridadPublica>(cityAppContext);
        }

        public Response<object> DeleteContactoSeguridadPublica(ContactoSeguridadPublica ContactoSeguridadPublica)
        {
            return DeleteCityApp.Save(ContactoSeguridadPublica);
        }
    }
}
