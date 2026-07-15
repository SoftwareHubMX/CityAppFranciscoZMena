using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ContactoSeguridadPublicaLogic
{
    public class CrearContactoSeguridadPublicaLogic
    {
        private ContactoSeguridadPublicaQuerys ContactoSeguridadPublicaQuerys;
        private ContactoSeguridadPublica ContactoSeguridadPublica = new ContactoSeguridadPublica();

        public CrearContactoSeguridadPublicaLogic(CityAppContext cityAppContext, ContactoSeguridadPublica contactoSeguridadPublica)
        {
            ContactoSeguridadPublicaQuerys = new ContactoSeguridadPublicaQuerys(cityAppContext);

            ContactoSeguridadPublica = contactoSeguridadPublica;
        }

        public Response<object> Crear()
        {
            return ContactoSeguridadPublicaQuerys.InsertContactoSeguridadPublica(ContactoSeguridadPublica);
        }
    }
}
