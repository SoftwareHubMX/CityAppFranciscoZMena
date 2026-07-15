using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys.Select
{
    public class RedesSocialesMunicipioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<RedSocialMunicipio> SelectCityApp = new SelectCityApp<RedSocialMunicipio>();

        private Paginado<RedSocialMunicipio> Paginado = new Paginado<RedSocialMunicipio>();

        public RedesSocialesMunicipioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<RedSocialMunicipio>> SelectRedesSocialesMunicipio(int idContactoMunicipio)
        {
            Response<IEnumerable<RedSocialMunicipio>> response = new Response<IEnumerable<RedSocialMunicipio>>();

            try
            {
                response.Data = CityAppContext.RedesSocialesMunicipio.Where(d => 
                d.IdContactoMunicipio == idContactoMunicipio).OrderByDescending(d => d.IdRedSocialMunicipio);

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
