using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAtencionContactoQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAtencionContactoQuerys
{
    public class TipoAtencionContactoQuerys
    {
        private TiposAtencionesContactoSelect TiposAtencionesContactoSelect;
        private TipoAtencionContactoSelect TipoAtencionContactoSelect;

        public TipoAtencionContactoQuerys(CityAppContext cityAppContext)
        {
            TiposAtencionesContactoSelect = new TiposAtencionesContactoSelect(cityAppContext);
            TipoAtencionContactoSelect = new TipoAtencionContactoSelect(cityAppContext);
        }

        public Response<IEnumerable<TipoAtencionContacto>> SelectTiposAtencionesContacto()
        {
            return TiposAtencionesContactoSelect.SelectTiposAtencionesContacto();
        }

        public Response<TipoAtencionContacto> SelectTipoAtencionContacto(int idTipoAtencionContacto)
        {
            return TipoAtencionContactoSelect.SelectTipoAtencionContacto(idTipoAtencionContacto);
        }
    }
}
