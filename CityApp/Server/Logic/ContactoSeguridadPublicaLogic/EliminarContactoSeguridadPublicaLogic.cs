using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ContactoSeguridadPublicaLogic
{
    public class EliminarContactoSeguridadPublicaLogic
    {
        private ContactoSeguridadPublicaQuerys ContactoSeguridadPublicaQuerys;
        private int IdContactoSeguridadPublica = 0;

        public EliminarContactoSeguridadPublicaLogic(CityAppContext cityAppContext, int idContactoSeguridadPublica)
        {
            ContactoSeguridadPublicaQuerys = new ContactoSeguridadPublicaQuerys(cityAppContext);

            IdContactoSeguridadPublica = idContactoSeguridadPublica;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<ContactoSeguridadPublica> responseContactoSeguridadPublica = new Response<ContactoSeguridadPublica>();
            responseContactoSeguridadPublica = ContactoSeguridadPublicaQuerys.SelectContactoSeguridadPublica(IdContactoSeguridadPublica);
            response.Status = responseContactoSeguridadPublica.Status;
            if (response.Status.Exito == 1)
            {
                response = ContactoSeguridadPublicaQuerys.DeleteContactoSeguridadPublica(responseContactoSeguridadPublica.Data);
            }
            return response;
        }
    }
}
