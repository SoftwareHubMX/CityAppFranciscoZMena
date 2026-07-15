using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CordeenadaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CordeenadaRutaLogic
{
    public class ActualizarCordeenadaRutaLogic
    {
        private CordeenadaRutaQuerys CordeenadaRutaQuerys;
        private CordeenadaRuta CordeenadaRuta;
        public ActualizarCordeenadaRutaLogic(CityAppContext cityAppContext, CordeenadaRuta cordeenadaRuta)
        {
            CordeenadaRutaQuerys = new CordeenadaRutaQuerys(cityAppContext);

            CordeenadaRuta = cordeenadaRuta;
        }

        public Response<object> Actualizar()
        {
            Response<object> response = new Response<object>();

            Response<CordeenadaRuta> reesponseCR = new Response<CordeenadaRuta>();
            reesponseCR = CordeenadaRutaQuerys.SelectCorddenadaRuta(CordeenadaRuta.IdRutaRecoleccion);
            response.Status = reesponseCR.Status;
            if (response.Status.Exito == 1)
            {
                CordeenadaRuta.IdCordeenadaRuta = reesponseCR.Data.IdCordeenadaRuta;
                response = CordeenadaRutaQuerys.UpdateCordeenadaRuta(CordeenadaRuta);
            }
            return response;
        }
    }
}
