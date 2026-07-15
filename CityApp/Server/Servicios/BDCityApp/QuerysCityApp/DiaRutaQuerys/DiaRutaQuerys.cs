
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys
{
    public class DiaRutaQuerys
    {
        private DiaRutaInsert DiaRutaInsert;
        private DiaRutaUpdate DiaRutaUpdate;
        private DiasRutaSelect DiasRutaSelect;
        private DiaRutaRecoleccionSelect DiaRutaRecoleccionSelect;
        private DiaRutaDelete DiaRutaDelete;
        

        public DiaRutaQuerys(CityAppContext cityAppContext)
        {
            DiaRutaInsert = new DiaRutaInsert(cityAppContext);
            DiaRutaUpdate = new DiaRutaUpdate(cityAppContext);
            DiasRutaSelect = new DiasRutaSelect(cityAppContext);
            DiaRutaRecoleccionSelect = new DiaRutaRecoleccionSelect(cityAppContext);
            DiaRutaDelete = new DiaRutaDelete(cityAppContext);
            
        }

        //Insert
        public Response<object> InsertDiaRuta(DiaRuta diaRuta)
        {
            return DiaRutaInsert.InsertDiaRuta(diaRuta);
        }

        public Response<object> UpdateDiaRuta(DiaRuta diaRuta)
        {
            return DiaRutaUpdate.UpdateDiaRuta(diaRuta);
        }
       
        public Response<IEnumerable<DiaRuta>> SelectDiasRuta(int idRutaRecoleccion)
        {
            return DiasRutaSelect.SelectDiasRuta(idRutaRecoleccion);
        }

        public Response<DiaRuta> SelectDiaRuta(int idDiaRuta)
        {
            return DiaRutaRecoleccionSelect.SelectDiaRuta(idDiaRuta);
        }
        public Response<object> DeleteDiaRuta(DiaRuta diaRuta)
        {
            return DiaRutaDelete.DeleteDiaRuta(diaRuta);
        }
    }
}
