using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys
{
    public class ColoniaQuerys
    {
        private ColoniaDelete ColoniaDelete;
        private ColoniaInsert ColoniaInsert;
        private ColoniaSelect ColoniaSelect;
        private ColoniasSelect ColoniasSelect;
        private ColoniaUpdate ColoniaUpdate;
       

        public ColoniaQuerys(CityAppContext cityAppContext)
        {
            ColoniaDelete = new ColoniaDelete(cityAppContext);
            ColoniaInsert = new ColoniaInsert(cityAppContext);
            ColoniaSelect = new ColoniaSelect(cityAppContext);
            ColoniasSelect = new ColoniasSelect(cityAppContext);
            ColoniaUpdate = new ColoniaUpdate(cityAppContext);
            
        }
        //Delete
        public Response<object> DeleteColonia(Colonia colonia)
        {
            return ColoniaDelete.DeleteColonia(colonia);
        }

        //Insert
        public Response<object> InsertColonia(Colonia colonia)
        {
            return ColoniaInsert.InsertColonia(colonia);
        }

        //Select
        public Response<Colonia> SelectColoniaIdColonia(int idColonia)
        {
            return ColoniaSelect.SelectColoniaIdColonia(idColonia);
        }
        public Response<IEnumerable<Colonia>> SelectColonias()
        {
            return ColoniasSelect.SelectColonias();
        }
        //Update
        public Response<object> UpdateColonia(Colonia colonia)
        {
            return ColoniaUpdate.UpdateColonia(colonia);
        }

        
    }
}
