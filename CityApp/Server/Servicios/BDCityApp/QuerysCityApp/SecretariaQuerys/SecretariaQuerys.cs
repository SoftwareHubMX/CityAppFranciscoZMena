using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SecretariaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys
{
    public class SecretariaQuerys
    {
        private SecretariaDelete SecretariaDelete;
        private SecretariaInsert SecretariaInsert;
        private SecretariaSelect SecretariaSelect;
        private SecretariasSelect SecretariasSelect;
        private SecretariaUpdate SecretariaUpdate;

        public SecretariaQuerys(CityAppContext cityAppContext)
        {
            SecretariaDelete = new SecretariaDelete(cityAppContext);
            SecretariaInsert = new SecretariaInsert(cityAppContext);
            SecretariaSelect = new SecretariaSelect(cityAppContext);
            SecretariasSelect = new SecretariasSelect(cityAppContext);
            SecretariaUpdate = new SecretariaUpdate(cityAppContext);    
        }
        //Delete
        public Response<object> DeleteSecretaria(Secretaria secretaria)
        {
            return SecretariaDelete.DeleteSecretaria(secretaria);
        }
        
        //Insert
        public Response<object> InsertSecretaria(Secretaria secretaria)
        {
            return SecretariaInsert.InsertSecretaria(secretaria);
        }

        //Select
        public Response<Secretaria> SelectSecretariaIdSecretaria(int idSecretaria)
        {
            return SecretariaSelect.SelectSecretariaIdSecretaria(idSecretaria);
        }
        public Response<IEnumerable<Secretaria>> SelectSecretarias()
        {
            return SecretariasSelect.SelectSecretarias();
        }
        public Response<IEnumerable<Secretaria>> SelectSecretariasFirltoSecretaria(FiltroSecretaria filtroSecretaria)
        {
            return SecretariasSelect.SelectSecretariasFirltoSecretaria(filtroSecretaria);
        }

        //Update
        public Response<object> UpdateSecretaria(Secretaria secretaria)
        {
            return SecretariaUpdate.UpdateSecretaria(secretaria);
        }
    }
}
