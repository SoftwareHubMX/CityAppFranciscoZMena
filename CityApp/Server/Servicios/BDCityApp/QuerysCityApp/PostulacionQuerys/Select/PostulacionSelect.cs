using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PostulacionQuerys.Select
{
    public class PostulacionSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Postulacion> SelectCityApp = new SelectCityApp<Postulacion>();

        public PostulacionSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<Postulacion> SelectPostulacionIdPostulacion(int idPostulacion)
        {
            Response<Postulacion> response = new Response<Postulacion>();

            try
            {
                response.Data = CityAppContext.Postulaciones.Where(d => d.IdPostulacion == idPostulacion).First();
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
