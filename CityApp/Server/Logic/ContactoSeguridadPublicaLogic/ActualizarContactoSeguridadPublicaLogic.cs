using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ContactoSeguridadPublicaLogic
{
    public class ActualizarContactoSeguridadPublicaLogic
    {
        private ContactoSeguridadPublicaQuerys ContactoSeguridadPublicaQuerys;
        private ContactoSeguridadPublica ContactoSeguridadPublica = new ContactoSeguridadPublica();

        public ActualizarContactoSeguridadPublicaLogic(CityAppContext cityAppContext, ContactoSeguridadPublica ContactoSeguridadPublica)
        {
            ContactoSeguridadPublicaQuerys = new ContactoSeguridadPublicaQuerys(cityAppContext);

            ContactoSeguridadPublica = ContactoSeguridadPublica;
        }

        public Response<object> Actualizar()
        {
            return ContactoSeguridadPublicaQuerys.UpdatePartulla(ContactoSeguridadPublica);
        }
    }
}
