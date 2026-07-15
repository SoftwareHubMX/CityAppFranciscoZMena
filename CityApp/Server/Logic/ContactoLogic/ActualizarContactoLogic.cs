using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ContactoLogic
{
    public class ActualizarContactoLogic
    {
        private ContactoQuerys ContactoQuerys;
        private Contacto Contacto = new Contacto();

        public ActualizarContactoLogic(CityAppContext cityAppContext, Contacto contacto)
        {
            ContactoQuerys = new ContactoQuerys(cityAppContext);
            Contacto = contacto;
        }

        public Response<object> Actualizar()
        {
            return ContactoQuerys.UpdateContacto(Contacto);
        }
    }
}
