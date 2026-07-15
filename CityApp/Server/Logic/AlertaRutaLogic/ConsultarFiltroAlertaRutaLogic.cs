using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusAlertaRutaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAlertaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaRutaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AlertaRutaLogic
{
    public class ConsultarFiltroAlertaRutaLogic
    {
        private AlertaRutaQuerys AlertaRutaQuerys;
        private List<AlertaRuta> Secretaria;
        private FiltroAlertaRuta FiltroAlertaRuta;


        public ConsultarFiltroAlertaRutaLogic(CityAppContext cityAppContex, FiltroAlertaRuta filtroAlertaRuta)
        {
            AlertaRutaQuerys = new AlertaRutaQuerys(cityAppContex);
            FiltroAlertaRuta = filtroAlertaRuta;
        }

        public Response<List<AlertaRuta>> Consultar()
        {
            Response<List<AlertaRuta>> response = new Response<List<AlertaRuta>>();

            Response<IEnumerable<AlertaRuta>> responseAlertaRuta = AlertaRutaQuerys.SelectAlertasRutaFirltoAlertaRuta(FiltroAlertaRuta);
            response.Status = responseAlertaRuta.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<AlertaRuta>();
                response.Data = responseAlertaRuta.Data.ToList();
                response.Info = new Info();
                response.Info = responseAlertaRuta.Info;
            }

            return response;
        }
    }
}
