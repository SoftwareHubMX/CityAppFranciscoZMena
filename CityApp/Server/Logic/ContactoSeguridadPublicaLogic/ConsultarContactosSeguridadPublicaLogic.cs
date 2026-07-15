using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoSeguridadPublicaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAtencionContactoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ContactoSeguridadPublicaLogic
{
    public class ConsultarContactosSeguridadPublicaLogic
    {
        private ContactoSeguridadPublicaQuerys ContactoSeguridadPublicaQuerys;
        private TipoAtencionContactoQuerys TipoAtencionContactoQuerys;

        public ConsultarContactosSeguridadPublicaLogic(CityAppContext cityAppContext)
        {
            ContactoSeguridadPublicaQuerys = new ContactoSeguridadPublicaQuerys(cityAppContext);
            TipoAtencionContactoQuerys = new TipoAtencionContactoQuerys(cityAppContext);
        }

        public Response<List<ContactoSeguridadPublica>> Consultar()
        {
            Response<List<ContactoSeguridadPublica>> response = new Response<List<ContactoSeguridadPublica>>();

            Response<IEnumerable<ContactoSeguridadPublica>> responseContactoSeguridadPublicaes = new Response<IEnumerable<ContactoSeguridadPublica>>();
            responseContactoSeguridadPublicaes = ContactoSeguridadPublicaQuerys.SelectContactosSeguridadPublica();
            response.Status = responseContactoSeguridadPublicaes.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<ContactoSeguridadPublica>();
                response.Data = responseContactoSeguridadPublicaes.Data.ToList();
                for(int i = 0; i < response.Data.Count; i++)
                {
                    Response<TipoAtencionContacto> responseTipoAtencionContacto = new Response<TipoAtencionContacto>();
                    responseTipoAtencionContacto = TipoAtencionContactoQuerys.SelectTipoAtencionContacto(response.Data[i].IdTipoAtencionContacto);
                    if(responseTipoAtencionContacto.Status.Exito == 1)
                    {
                        response.Data[i].TipoAtencionContacto = new TipoAtencionContacto();
                        response.Data[i].TipoAtencionContacto = responseTipoAtencionContacto.Data;
                    }
                }
            }
            return response;
        }
    }
}
