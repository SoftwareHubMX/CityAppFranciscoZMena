using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoMunicipioQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoMunicipioQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoMunicipioQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoMunicipioQuerys
{
    public class ContactoMunicipioQuerys
    {
        private ContactoMunicipioInsert ContactoMunicipioInsert;
        private ContactoMunicipioSelect ContactoMunicipioSelect;
        private ContactoMunicipioUpdate ContactoMunicipioUpdate;

        public ContactoMunicipioQuerys(CityAppContext cityAppContext)
        {
            ContactoMunicipioInsert = new ContactoMunicipioInsert(cityAppContext);
            ContactoMunicipioSelect = new ContactoMunicipioSelect(cityAppContext);
            ContactoMunicipioUpdate = new ContactoMunicipioUpdate(cityAppContext);
        }

        //insert
        public Response<object> InsertContactoMunicipio(ContactoMunicipio ContactoMunicipio)
        {
            return ContactoMunicipioInsert.InsertContactoMunicipio(ContactoMunicipio);
        }

        //select
        public Response<ContactoMunicipio> SelectContactoMunicipioIdContactoMunicipio(int idContactoMunicipio)
        {
            return ContactoMunicipioSelect.SelectContactoMunicipioIdContactoMunicipio(idContactoMunicipio);
        }
        public Response<ContactoMunicipio> SelectLastContactoMunicipio()
        {
            return ContactoMunicipioSelect.SelectLastContactoMunicipio();
        }

        //Update
        public Response<object> UpdateContactoMunicipio(ContactoMunicipio ContactoMunicipio)
        {
            return ContactoMunicipioUpdate.UpdateContactoMunicipio(ContactoMunicipio);
        }
    }
}
