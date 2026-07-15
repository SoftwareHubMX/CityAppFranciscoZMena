using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys
{
    public class ContactoSeguridadPublicaQuerys
    {
        private ContactoSeguridadPublicaInsert ContactoSeguridadPublicaInsert;
        private ContactoSeguridadPublicaSelect ContactoSeguridadPublicaSelect;
        private ContactosSeguridadPublicaSelect ContactosSeguridadPublicaSelect;
        private ContactoSeguridadPublicaDelete ContactoSeguridadPublicaDelete;
        private ContactoSeguridadPublicaUpdate ContactoSeguridadPublicaUpdate;

        public ContactoSeguridadPublicaQuerys(CityAppContext cityAppContext)
        {
            ContactoSeguridadPublicaInsert = new ContactoSeguridadPublicaInsert(cityAppContext);
            ContactoSeguridadPublicaSelect = new ContactoSeguridadPublicaSelect(cityAppContext);
            ContactosSeguridadPublicaSelect = new ContactosSeguridadPublicaSelect(cityAppContext);
            ContactoSeguridadPublicaDelete = new ContactoSeguridadPublicaDelete(cityAppContext);
        }

        //Insert
        public Response<object> InsertContactoSeguridadPublica(ContactoSeguridadPublica ContactoSeguridadPublica)
        {
            return ContactoSeguridadPublicaInsert.InsertContactoSeguridadPublica(ContactoSeguridadPublica);
        }

        //select
        public Response<ContactoSeguridadPublica> SelectContactoSeguridadPublica(int idContactoSeguridadPublica)
        {
            return ContactoSeguridadPublicaSelect.SelectContactoSeguridadPublica(idContactoSeguridadPublica);
        }
        public Response<IEnumerable<ContactoSeguridadPublica>> SelectContactosSeguridadPublica()
        {
            return ContactosSeguridadPublicaSelect.SelectContactosSeguridadPublica();
        }

        //Update
        public Response<object> UpdatePartulla(ContactoSeguridadPublica ContactoSeguridadPublica)
        {
            return ContactoSeguridadPublicaUpdate.UpdateContactoSeguridadPublica(ContactoSeguridadPublica);
        }

        //Delete
        public Response<object> DeleteContactoSeguridadPublica(ContactoSeguridadPublica ContactoSeguridadPublica)
        {
            return ContactoSeguridadPublicaDelete.DeleteContactoSeguridadPublica(ContactoSeguridadPublica);
        }
    }
}
