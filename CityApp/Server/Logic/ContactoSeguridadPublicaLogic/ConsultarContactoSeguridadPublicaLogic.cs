using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAtencionContactoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ContactoSeguridadPublicaLogic
{
    public class ConsultarContactoSeguridadPublicaLogic
    {
        private ContactoSeguridadPublicaQuerys ContactoSeguridadPublicaQuerys;
        private TipoAtencionContactoQuerys TipoAtencionContactoQuerys;
        private int IdContactoSeguridadPublica = 0;

        public ConsultarContactoSeguridadPublicaLogic(CityAppContext cityAppContext, int idContactoSeguridadPublica)
        {
            ContactoSeguridadPublicaQuerys = new ContactoSeguridadPublicaQuerys(cityAppContext);
            TipoAtencionContactoQuerys = new TipoAtencionContactoQuerys(cityAppContext);

            IdContactoSeguridadPublica = idContactoSeguridadPublica;
        }

        public Response<ContactoSeguridadPublica> Consultar()
        {
            Response<ContactoSeguridadPublica> response = new Response<ContactoSeguridadPublica>();
            response = ContactoSeguridadPublicaQuerys.SelectContactoSeguridadPublica(IdContactoSeguridadPublica);
            if(response.Status.Exito == 1)
            {
                Response<TipoAtencionContacto> responseTipoAtencionContacto = new Response<TipoAtencionContacto>();
                responseTipoAtencionContacto = TipoAtencionContactoQuerys.SelectTipoAtencionContacto(response.Data.IdTipoAtencionContacto);
                response.Status = responseTipoAtencionContacto.Status;
                if(response.Status.Exito == 1)
                {
                    response.Data.TipoAtencionContacto = new TipoAtencionContacto();
                    response.Data.TipoAtencionContacto = responseTipoAtencionContacto.Data;
                }
            }
            return response;
        }
    }
}
