using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys
{
    public class NormatividadQuerys
    {
        private NormatividadInsert NormatividadInsert;
        private NormatividadesSelect NormatividadesSelect;
        private NormatividadSelect NormatividadSelect;
        private NormatividadDelete NormatividadDelete;
        private NormatividadUpdate NormatividadUpdate;

        public NormatividadQuerys(CityAppContext cityAppContext)
        {
            NormatividadInsert = new NormatividadInsert(cityAppContext);
            NormatividadSelect = new NormatividadSelect(cityAppContext);
            NormatividadesSelect = new NormatividadesSelect(cityAppContext);
            NormatividadDelete = new NormatividadDelete(cityAppContext);
        }

        //Insert
        public Response<object> InsertNormatividad(Normatividad Normatividad)
        {
            return NormatividadInsert.InsertNormatividad(Normatividad);
        }

        //select
        public Response<Normatividad> SelectNormatividad(int idNormatividad)
        {
            return NormatividadSelect.SelectNormatividad(idNormatividad);
        }

        public Response<IEnumerable<Normatividad>> SelectNormatividades()
        {
            return NormatividadesSelect.SelectNormatividades();
        }

        //Update
        public Response<object> UpdatePartulla(Normatividad Normatividad)
        {
            return NormatividadUpdate.UpdateNormatividad(Normatividad);
        }

        //Delete
        public Response<object> DeleteNormatividad(Normatividad Normatividad)
        {
            return NormatividadDelete.DeleteNormatividad(Normatividad);
        }
    }
}
