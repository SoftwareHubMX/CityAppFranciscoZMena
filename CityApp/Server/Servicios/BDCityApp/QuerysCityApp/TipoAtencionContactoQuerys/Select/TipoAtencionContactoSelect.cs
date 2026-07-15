using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAtencionContactoQuerys.Select
{
    public class TipoAtencionContactoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoAtencionContacto> SelectCityApp = new SelectCityApp<TipoAtencionContacto>();

        public TipoAtencionContactoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TipoAtencionContacto> SelectTipoAtencionContacto(int idTipoAtencionContacto)
        {
            Response<TipoAtencionContacto> response = new Response<TipoAtencionContacto>();

            try
            {
                response.Data = CityAppContext.TiposAtencionesContacto.Where(d => d.IdTipoAtencionContacto == idTipoAtencionContacto).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
