using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoMunicipioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ContactoMunicipioLogic
{
    public class CrearContactoMunicipioLogic
    {
        private ContactoMunicipioQuerys ContactoMunicipioQuerys;
        private ContactoMunicipio ContactoMunicipio = new ContactoMunicipio();

        public CrearContactoMunicipioLogic(CityAppContext cityAppContext, ContactoMunicipio contactoMunicipio)
        {
            ContactoMunicipioQuerys = new ContactoMunicipioQuerys(cityAppContext);

            ContactoMunicipio = contactoMunicipio;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responseInsert = new Response<object>();
            responseInsert = ContactoMunicipioQuerys.InsertContactoMunicipio(ContactoMunicipio);
            response.Status = responseInsert.Status;
            if(response.Status.Exito == 1)
            {
                Response<ContactoMunicipio> responseContactoMunicipio = new Response<ContactoMunicipio>();
                responseContactoMunicipio = ContactoMunicipioQuerys.SelectLastContactoMunicipio();
                response.Status = responseContactoMunicipio.Status;
                if(response.Status.Exito == 1)
                {
                    response.Data = responseContactoMunicipio.Data.IdContactoMunicipio;
                }
            }

            return response;
        }
    }
}
