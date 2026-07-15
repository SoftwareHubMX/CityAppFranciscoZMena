using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys
{
    public class ContactoQuerys
    {
        private ContactoInsert ContactoInsert;
        private ContactoSelect ContactoSelect;
        private CorreoSelect CorreoSelect;
        private ContactoUpdate ContactoUpdate;

        public ContactoQuerys(CityAppContext cityAppContext)
        {
            ContactoInsert = new ContactoInsert(cityAppContext);
            CorreoSelect = new CorreoSelect(cityAppContext);
            ContactoSelect = new ContactoSelect(cityAppContext);
            ContactoUpdate = new ContactoUpdate(cityAppContext);
        }

        //insert
        public Response<object> InsertContacto(Contacto contacto)
        {
            return ContactoInsert.InsertContacto(contacto);
        }

        //select
        public Response<Contacto> SelectContactoIdCenta(int idCuenta)
        {
            return ContactoSelect.SelectContactoIdCuenta(idCuenta);
        }
        public Response<string> SelectCorreoIdCuenta(int idCuenta)
        {
            return CorreoSelect.SelectCorreoIdCuenta(idCuenta);
        }
        public Response<string> SelectCorreoCorreo(string correo)
        {
            return CorreoSelect.SelectCorreoCorreo(correo);
        }

        //Update
        public Response<object> UpdateContacto(Contacto Contacto)
        {
            return ContactoUpdate.UpdateContacto(Contacto);
        }
    }
}
