using CityApp.Client.Services.ApiRest.ContactoSeguridadPublicaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaContactoSeguridadPublicaLogic
{
    public class InsertContactoSeguridadPublicaLogic
    {
        private ContactoSeguridadPublicaPeticiones ContactoSeguridadPublicaPeticiones;
        private Codificador Codificador = new Codificador();

        public InsertContactoSeguridadPublicaLogic(HttpClient cliente)
        {
            ContactoSeguridadPublicaPeticiones = new ContactoSeguridadPublicaPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, ContactoSeguridadPublica contactoSeguridadPublica)
        {
            contactoSeguridadPublica.Numero = Codificador.Encrypt(contactoSeguridadPublica.Numero);
            Response<object> response = await ContactoSeguridadPublicaPeticiones.crearContactoSeguridadPublica(token, contactoSeguridadPublica);
            if(response.Status.Exito != 1)
            {
                contactoSeguridadPublica.Numero = Codificador.Decrypt(contactoSeguridadPublica.Numero);
            }
            return response;
        }
    }
}
