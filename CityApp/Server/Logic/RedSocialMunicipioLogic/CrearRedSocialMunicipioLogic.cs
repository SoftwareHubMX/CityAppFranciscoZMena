using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.RedSocialMunicipioLogic
{
    public class CrearRedSocialMunicipioLogic
    {
        private RedSocialMunicipioQuerys RedSocialMunicipioQuerys;
        private RedSocialMunicipio RedSocialMunicipio = new RedSocialMunicipio();

        public CrearRedSocialMunicipioLogic(CityAppContext cityAppContext, RedSocialMunicipio redSocialMunicipio)
        {
            RedSocialMunicipioQuerys = new RedSocialMunicipioQuerys(cityAppContext);
            RedSocialMunicipio = redSocialMunicipio;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responseInsertRedSocialMunicipio = new Response<object>();
            responseInsertRedSocialMunicipio = RedSocialMunicipioQuerys.InsertRedSocialMunicipio(RedSocialMunicipio);
            response.Status = responseInsertRedSocialMunicipio.Status;
            if(response.Status.Exito == 1)
            {
                Response<RedSocialMunicipio> responseRedSocialMunicipio = new Response<RedSocialMunicipio>();
                responseRedSocialMunicipio = RedSocialMunicipioQuerys.SelectLastRedSocialMunicipio(RedSocialMunicipio.IdTipoRedSocial, RedSocialMunicipio.IdContactoMunicipio, RedSocialMunicipio.Ruta);
                response.Status = responseRedSocialMunicipio.Status;
                if(response.Status.Exito == 1)
                {
                    response.Data = responseRedSocialMunicipio.Data.IdRedSocialMunicipio;
                }
            }

            return response;
        }
    }
}
