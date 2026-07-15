using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys
{
    public class RedSocialMunicipioQuerys
    {
        private RedSocialMunicipioInsert RedSocialMunicipioInsert;
        private RedSocialMunicipioSelect RedSocialMunicipioSelect;
        private RedesSocialesMunicipioSelect RedesSocialesMunicipioSelect;
        private RedSocialMunicipioUpdate RedSocialMunicipioUpdate;
        private RedSocialMunicipioDelete RedSocialMunicipioDelete;

        public RedSocialMunicipioQuerys(CityAppContext cityAppContext)
        {
            RedSocialMunicipioInsert = new RedSocialMunicipioInsert(cityAppContext);
            RedSocialMunicipioSelect = new RedSocialMunicipioSelect(cityAppContext);
            RedesSocialesMunicipioSelect = new RedesSocialesMunicipioSelect(cityAppContext);
            RedSocialMunicipioUpdate = new RedSocialMunicipioUpdate(cityAppContext);
            RedSocialMunicipioDelete = new RedSocialMunicipioDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertRedSocialMunicipio(RedSocialMunicipio RedSocialMunicipio)
        {
            return RedSocialMunicipioInsert.InsertRedSocialMunicipio(RedSocialMunicipio);
        }

        //select
        public Response<RedSocialMunicipio> SelectRedSocialMunicipioIdRedSocialMunicipio(int idRedSocialMunicipio)
        {
            return RedSocialMunicipioSelect.SelectRedSocialMunicipioIdRedSocialMunicipio(idRedSocialMunicipio);
        }
        public Response<RedSocialMunicipio> SelectLastRedSocialMunicipio(int idTipoRedSocial, int idContactoMunicipio, string ruta)
        {
            return RedSocialMunicipioSelect.SelectLastRedSocialMunicipio(idTipoRedSocial, idContactoMunicipio, ruta);
        }
        public Response<IEnumerable<RedSocialMunicipio>> SelectRedesSocialesMunicipio(int idContactoMunicipio)
        {
            return RedesSocialesMunicipioSelect.SelectRedesSocialesMunicipio(idContactoMunicipio);
        }

        //Update
        public Response<object> UpdateRedSocialMunicipio(RedSocialMunicipio RedSocialMunicipio)
        {
            return RedSocialMunicipioUpdate.UpdateRedSocialMunicipio(RedSocialMunicipio);
        }

        //Delete
        public Response<object> DeleteRedSocialMunicipio(RedSocialMunicipio RedSocialMunicipio)
        {
            return RedSocialMunicipioDelete.DeleteRedSocialMunicipio(RedSocialMunicipio);
        }
    }
}
