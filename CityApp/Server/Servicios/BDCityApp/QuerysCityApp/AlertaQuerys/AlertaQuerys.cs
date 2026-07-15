using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys
{
    public class AlertaQuerys
    {
        private AlertaInsert AlertaInsert;
        private AlertaSelect AlertaSelect;
        private AlertasSelect AlertasSelect;
        private AlertasIdCuentaSelect AlertasIdCuentaSelect;
        private AlertaUpdate AlertaUpdate;
        private AlertaDelete AlertaDelete;

        public AlertaQuerys(CityAppContext cityAppContext)
        {
            AlertaInsert = new AlertaInsert(cityAppContext);
            AlertaSelect = new AlertaSelect(cityAppContext);
            AlertasSelect = new AlertasSelect(cityAppContext);
            AlertasIdCuentaSelect = new AlertasIdCuentaSelect(cityAppContext);
            AlertaUpdate = new AlertaUpdate(cityAppContext);
            AlertaDelete = new AlertaDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertAlerta(Alerta Alerta)
        {
            return AlertaInsert.InsertAlerta(Alerta);
        }

        //select
        public Response<Alerta> SelectAlertaIdAlerta(int idAlerta)
        {
            return AlertaSelect.SelectAlertaIdAlerta(idAlerta);
        }
        public Response<IEnumerable<Alerta>> SelectAlertas(int idEstatusAlerta)
        {
            return AlertasSelect.SelectAlertas(idEstatusAlerta);
        }
        public Response<IEnumerable<Alerta>> SelectAlertasIdCuenta(int idCuenta, int idEstatusAlerta)
        {
            return AlertasIdCuentaSelect.SelectAlertasIdCuenta(idCuenta, idEstatusAlerta);
        }

        //update
        public Response<object> UpdateAlerta(Alerta Alerta)
        {
            return AlertaUpdate.UpdateAlerta(Alerta);
        }

        //delete
        public Response<object> DeleteAlerta(Alerta Alerta)
        {
            return AlertaDelete.DeleteAlerta(Alerta);
        }
    }
}
