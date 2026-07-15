using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CordeenadaRutaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CordeenadaRutaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CordeenadaRutaQuerys
{
    public class CordeenadaRutaQuerys
    {
        private CordeenadaRutaSelect CordeenadaRutaSelect;
        private CordeenadaRutaUpdate CordeenadaRutaUpdate;

        public CordeenadaRutaQuerys(CityAppContext cityAppContext)
        {
            CordeenadaRutaSelect = new CordeenadaRutaSelect(cityAppContext);
            CordeenadaRutaUpdate = new CordeenadaRutaUpdate(cityAppContext);    
        }

        public Response<CordeenadaRuta> SelectCorddenadaRuta(int idRutaRecoleccion)
        {
            return CordeenadaRutaSelect.SelectCorddenadaRuta(idRutaRecoleccion);
        }
        public Response<object> UpdateCordeenadaRuta(CordeenadaRuta cordeenadaRuta)
        {
            return CordeenadaRutaUpdate.UpdateCordeenadaRuta(cordeenadaRuta);
        }
    }
}
