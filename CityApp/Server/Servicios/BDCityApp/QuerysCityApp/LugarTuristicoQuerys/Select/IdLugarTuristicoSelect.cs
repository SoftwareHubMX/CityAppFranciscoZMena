using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys.Select
{
    public class IdLugarTuristicoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdLugarTuristicoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<int> SelectIdLugarTuristicoNombre(string nombre)
        {
            Response<int> response = new Response<int>();

            try
            {
                response.Data = (from data in CityAppContext.LugaresTuristicos
                                 orderby data.IdLugarTuristico
                                 where data.Nombre == nombre
                                 select data.IdLugarTuristico).First();

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
