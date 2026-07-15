using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys
{
    public class ColoniaRutaRecoleccionQuerys
    {
        private ColoniaRutaRecoleccionDelete ColoniaRutaRecoleccionDelete;
        private ColoniaRutaRecoleccionInsert ColoniaRutaRecoleccionInsert;
        private ColoniaRutaRecoleccionSelect ColoniaRutaRecoleccionSelect;
        private ColoniasRutaRecoleccionSelect ColoniasRutaRecoleccionSelect;
        
        public ColoniaRutaRecoleccionQuerys(CityAppContext cityAppContext)
        {
            ColoniaRutaRecoleccionDelete = new ColoniaRutaRecoleccionDelete(cityAppContext);
            ColoniaRutaRecoleccionInsert = new ColoniaRutaRecoleccionInsert(cityAppContext);
            ColoniaRutaRecoleccionSelect = new ColoniaRutaRecoleccionSelect(cityAppContext);
            ColoniasRutaRecoleccionSelect = new ColoniasRutaRecoleccionSelect(cityAppContext);
            
        }
        //Delete
        public Response<object> DeleteColoniaRutaRecoleccion(ColoniaRutaRecoleccion coloniaRutaRecoleccion)
        {
            return ColoniaRutaRecoleccionDelete.DeleteColoniaRutaRecoleccion(coloniaRutaRecoleccion);
        }

        //Insert
        public Response<object> InsertColoniaRutaRecoleccion(ColoniaRutaRecoleccion coloniaRutaRecoleccion)
        {
            return ColoniaRutaRecoleccionInsert.InsertColoniaRutaRelcoleccion(coloniaRutaRecoleccion);
        }

        //Select
        public Response<ColoniaRutaRecoleccion> SelectColoniaRutaRecoleccionIdColoniaRutaRecoleccion(int idColonia, int idRutaRecoleccion)
        {
            return ColoniaRutaRecoleccionSelect.SelectColoniaRutaRecoleccionIdColoniaRutaRecoleccion(idColonia, idRutaRecoleccion);
        }
        public Response<IEnumerable<ColoniaRutaRecoleccion>> SelectColoniasRutaRecoleccion(int idRutaRecolecccion)
        {
            return ColoniasRutaRecoleccionSelect.SelectColoniasRutaRecoleccion(idRutaRecolecccion);
        }
        

        
    }
}
