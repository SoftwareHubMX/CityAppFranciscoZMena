using CityApp.Client.Services.ApiRest.ContactoSeguridadPublicaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaContactoSeguridadPublicaLogic
{
    public class DeleteContactoSeguridadPublica
    {
        private ContactoSeguridadPublicaPeticiones ContactoSeguridadPublicaPeticiones;

        public DeleteContactoSeguridadPublica(HttpClient cliente)
        {
            ContactoSeguridadPublicaPeticiones = new ContactoSeguridadPublicaPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idContactoSeguridadPublica)
        {
            Response<object> response = await ContactoSeguridadPublicaPeticiones.eliminarContactoSeguridadPublica(token, idContactoSeguridadPublica);
            return response;
        }
    }
}
