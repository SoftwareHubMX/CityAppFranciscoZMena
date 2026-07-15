using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoMunicipioQuerys.Update
{
    public class ContactoMunicipioUpdate
    {
        private UpdateCityApp<ContactoMunicipio> UpdateCityApp;

        public ContactoMunicipioUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<ContactoMunicipio>(cityAppContext);
        }

        public Response<object> UpdateContactoMunicipio(ContactoMunicipio ContactoMunicipio)
        {
            return UpdateCityApp.Save(ContactoMunicipio);
        }
    }
}
