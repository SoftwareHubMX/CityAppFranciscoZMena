using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DireccionLugarTuristicoQuerys.Select
{
    public class DireccionLugarTuristicoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<DireccionLugarTuristico> SelectCityApp = new SelectCityApp<DireccionLugarTuristico>();

        public DireccionLugarTuristicoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<DireccionLugarTuristico> SelectDireccionLugaTuristicoIdLugarTuristico(int idLugarTuristico)
        {
            Response<DireccionLugarTuristico> response = new Response<DireccionLugarTuristico>();

            try
            {
                response.Data = (from data in CityAppContext.DireccionesLugaresTuristicos
                                orderby data.IdDireccionLugarTuristico
                                where data.IdLugarTuristico == idLugarTuristico
                                select data).Last();

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
