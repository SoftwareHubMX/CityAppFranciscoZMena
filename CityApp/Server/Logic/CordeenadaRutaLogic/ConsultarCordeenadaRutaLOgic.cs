using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CordeenadaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CordeenadaRutaLogic
{
    public class ConsultarCordeenadaRutaLOgic
    {
        private CordeenadaRutaQuerys CordeenadaRutaQuerys;


        private int IdRutaRecoleecion;
        private CordeenadaRuta CordeenadaRuta;

        public ConsultarCordeenadaRutaLOgic(CityAppContext cityAppContetx, int idRutaRecoleccion)
        {
            CordeenadaRutaQuerys = new CordeenadaRutaQuerys(cityAppContetx);

            IdRutaRecoleecion = idRutaRecoleccion;
        }

        public Response<CordeenadaRuta> Consultar()
        {
            return CordeenadaRutaQuerys.SelectCorddenadaRuta(IdRutaRecoleecion);
        }
    }
}
