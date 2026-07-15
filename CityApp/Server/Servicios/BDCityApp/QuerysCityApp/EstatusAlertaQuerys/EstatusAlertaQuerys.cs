using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusAlertaQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusAlertaQuerys
{
    public class EstatusAlertaQuerys
    {
        private EstatusAlertaSelect EstatusAlertaSelect;
        private EstatusAletaIdEstatusAlertaSelect EstatusAletaIdEstatusAlertaSelect;

        public EstatusAlertaQuerys(CityAppContext cityAppContext)
        {
            EstatusAlertaSelect = new EstatusAlertaSelect(cityAppContext);
            EstatusAletaIdEstatusAlertaSelect = new EstatusAletaIdEstatusAlertaSelect(cityAppContext);
        }

        //select
        public Response<IEnumerable<EstatusAlerta>> SelectEstatusAlerta()
        {
            return EstatusAlertaSelect.SelectEstatusAlertaSelect();
        }

        public Response<EstatusAlerta> SelectEstatusAlertaIdEstatusAlerta(int idEstatusAlerta)
        {
            return EstatusAletaIdEstatusAlertaSelect.SelectEstatusAletaIdEstatusAlertaSelect(idEstatusAlerta);
        }
    }
}
