using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoMunicipioQuerys.Insert
{
    public class ContactoMunicipioInsert
    {
        private InsertCityApp<ContactoMunicipio> InsertCityApp;

        public ContactoMunicipioInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ContactoMunicipio>(cityAppContext);
        }

        public Response<object> InsertContactoMunicipio(ContactoMunicipio ContactoMunicipio)
        {
            return InsertCityApp.Save(ContactoMunicipio);
        }
    }
}
