using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys.Insert
{
    public class ContactoSeguridadPublicaInsert
    {
        private InsertCityApp<ContactoSeguridadPublica> InsertCityApp;

        public ContactoSeguridadPublicaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ContactoSeguridadPublica>(cityAppContext);
        }

        public Response<object> InsertContactoSeguridadPublica(ContactoSeguridadPublica ContactoSeguridadPublica)
        {
            return InsertCityApp.Save(ContactoSeguridadPublica);
        }
    }
}
