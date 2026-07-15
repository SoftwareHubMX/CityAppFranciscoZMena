using CityApp.Client.Services.ApiRest.ContactoSeguridadPublicaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaContactoSeguridadPublicaLogic
{
    public class SelectContactosSeguridadPublica
    {
        private ContactoSeguridadPublicaPeticiones ContactoSeguridadPublicaPeticiones;
        private Codificador Codificador = new Codificador();

        public SelectContactosSeguridadPublica(HttpClient cliente)
        {
            ContactoSeguridadPublicaPeticiones = new ContactoSeguridadPublicaPeticiones(cliente);
        }

        public async Task<Response<List<ContactoSeguridadPublica>>> SelectAll(string token)
        {
            Response<List<ContactoSeguridadPublica>> response = await ContactoSeguridadPublicaPeticiones.consultarContactoSeguridadPublicas(token);
            if(response.Status.Exito == 1)
            {
                for(int i = 0; i < response.Data.Count; i++)
                {
                    response.Data[i].Numero = (response.Data[i].Numero != "NA") ? Codificador.Decrypt(response.Data[i].Numero): "NA";
                }
            }
            return response;
        }
    }
}
