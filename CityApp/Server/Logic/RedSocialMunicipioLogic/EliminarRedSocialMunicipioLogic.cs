using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.RedSocialMunicipioLogic
{
    public class EliminarRedSocialMunicipioLogic
    {
        private RedSocialMunicipioQuerys RedSocialMunicipioQuerys;
        private int IdRedSocialMunicipio = 0;

        public EliminarRedSocialMunicipioLogic(CityAppContext cityAppContext, int idRedSocialMunicipio)
        {
            RedSocialMunicipioQuerys = new RedSocialMunicipioQuerys(cityAppContext);

            IdRedSocialMunicipio = idRedSocialMunicipio;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<RedSocialMunicipio> responseRedSocialMunicipio = new Response<RedSocialMunicipio>();
            responseRedSocialMunicipio = RedSocialMunicipioQuerys.SelectRedSocialMunicipioIdRedSocialMunicipio(IdRedSocialMunicipio);
            response.Status = responseRedSocialMunicipio.Status;
            if (response.Status.Exito == 1)
            {
                response = RedSocialMunicipioQuerys.DeleteRedSocialMunicipio(responseRedSocialMunicipio.Data);
            }
            return response;
        }
    }
}
