using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys.Uptate;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.RutaRecoleccionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys
{
    public class RutaRecoleccionQuerys
    {

        private RutaRecoleccionDelete RutaRecoleccionDelete;
        private RutaRecoleccionInsert RutaRecoleccionInsert;
        private RutaRecoleccionSelect RutaRecoleccionSelect;
        private RutasRecoleccionSelect RutasRecoleccionSelect;
        private RutaRecoleccionUpdate RutaRecoleccionUpdate;

        public RutaRecoleccionQuerys(CityAppContext cityAppContext)
        {
            RutaRecoleccionDelete = new RutaRecoleccionDelete(cityAppContext);
            RutaRecoleccionInsert = new RutaRecoleccionInsert(cityAppContext);
            RutaRecoleccionSelect = new RutaRecoleccionSelect(cityAppContext);
            RutasRecoleccionSelect = new RutasRecoleccionSelect(cityAppContext);
            RutaRecoleccionUpdate = new RutaRecoleccionUpdate(cityAppContext);
        }
        //Delete
        public Response<object> DeleteRutaRecoleccion(RutaRecoleccion rutaRecoleccion)
        {
            return RutaRecoleccionDelete.DeleteRutaRecoleccion(rutaRecoleccion);
        }

        //Insert
        public Response<object> InsertRutaRecoleccion(RutaRecoleccion rutaRecoleccion)
        {
            return RutaRecoleccionInsert.InsertRutaRecoleccion(rutaRecoleccion);
        }

        //Select
        public Response<RutaRecoleccion> SelectRutaRecoleccionIdRutaRecoleccion(int idRutaRecoleccion)
        {
            return RutaRecoleccionSelect.SelectRutaRecoleccionIdRutaRecoleccion(idRutaRecoleccion);
        }
        public Response<RutaRecoleccion> SelectLastIdRutaRecoleccion()
        {
            return RutaRecoleccionSelect.SelectLastIdRutaRecoleccion();
        }
        public Response<IEnumerable<RutaRecoleccion>> SelectRutaRecoleccionFirltoRutaRecoleccion(FiltroRutaRecoleccion filtroRutaRecoleccion)
        {
            return RutasRecoleccionSelect.SelectRutaRecoleccionFirltoRutaRecoleccion(filtroRutaRecoleccion);
        }
        public Response<IEnumerable<RutaRecoleccion>> SelectRutasRecoleccion()
        {
            return RutasRecoleccionSelect.SelectRutasRecoleccion();
        }

        //Update
        public Response<object> UpdateRutaRecoleccion(RutaRecoleccion rutaRecoleccion)
        {
            return RutaRecoleccionUpdate.UpdateRutaRecoleccion(rutaRecoleccion);
        }
    }
}
