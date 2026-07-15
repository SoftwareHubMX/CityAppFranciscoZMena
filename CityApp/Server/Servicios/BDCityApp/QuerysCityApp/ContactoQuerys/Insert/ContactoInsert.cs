using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys.Insert
{
    public class ContactoInsert
    {
        private InsertCityApp<Contacto> InsertCityApp;

        public ContactoInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Contacto>(cityAppContext);
        }

        public Response<object> InsertContacto(Contacto contacto)
        {
            return InsertCityApp.Save(contacto);
        }
    }
}
