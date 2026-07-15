
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaRutaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys
{
    public class AlertaRutaQuerys
    {
        private AlertaRutaInsert AlertaRutaInsert;
        private AlertaRutaSelect AlertaRutaSelect;
        private AlertasRutaSelect AlertasRutaSelect;      
        private AlertaRutaUpdate AlertaRutaUpdate;
       

        public AlertaRutaQuerys(CityAppContext cityAppContext)
        {
            AlertaRutaInsert = new AlertaRutaInsert(cityAppContext);
            AlertaRutaSelect = new AlertaRutaSelect(cityAppContext);
            AlertasRutaSelect = new AlertasRutaSelect(cityAppContext);           
            AlertaRutaUpdate = new AlertaRutaUpdate(cityAppContext);           
        }

        //insert
        public Response<object> InsertAlertaRuta(AlertaRuta alertaRuta)
        {
            return AlertaRutaInsert.InsertAlertaRuta(alertaRuta);
        }

        //select
        public Response<AlertaRuta> SelectAlertaRutaIdAlertaRuta(int idAlertaRuta)
        {
            return AlertaRutaSelect.SelectAlertaRutaIdAlertaRuta(idAlertaRuta);
        }
        public Response<IEnumerable<AlertaRuta>> SelectAlertasRuta(int idRutaRecoleccion)
        {
            return AlertasRutaSelect.SelectAlertasRuta(idRutaRecoleccion);
        }
        public Response<IEnumerable<AlertaRuta>> SelectAlertasRutaFirltoAlertaRuta(FiltroAlertaRuta filtroAlertaRuta)
        {
            return AlertasRutaSelect.SelectAlertasRutaFirltoAlertaRuta(filtroAlertaRuta);
        }

        //update
        public Response<object> UpdateAlertaRuta(AlertaRuta alertaRuta)
        {
            return AlertaRutaUpdate.UpdateAlertaRuta(alertaRuta);
        }
    }
}
