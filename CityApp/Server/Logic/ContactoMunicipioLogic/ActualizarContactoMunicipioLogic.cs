using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoMunicipioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ContactoMunicipioLogic
{
    public class ActualizarContactoMunicipioLogic
    {
        private ContactoMunicipioQuerys ContactoMunicipioQuerys;
        private ContactoMunicipio ContactoMunicipio = new ContactoMunicipio();

        public ActualizarContactoMunicipioLogic(CityAppContext cityAppContext, ContactoMunicipio ContactoMunicipio)
        {
            ContactoMunicipioQuerys = new ContactoMunicipioQuerys(cityAppContext);

            ContactoMunicipio = ContactoMunicipio;
        }

        public Response<object> Actualizar()
        {
            return ContactoMunicipioQuerys.UpdateContactoMunicipio(ContactoMunicipio);
        }
    }
}
