using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys.Update
{
    public class ContactoUpdate
    {
        private UpdateCityApp<Contacto> UpdateCityApp;

        public ContactoUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Contacto>(cityAppContext);
        }

        public Response<object> UpdateContacto(Contacto Contacto)
        {
            return UpdateCityApp.Save(Contacto);
        }
    }
}
