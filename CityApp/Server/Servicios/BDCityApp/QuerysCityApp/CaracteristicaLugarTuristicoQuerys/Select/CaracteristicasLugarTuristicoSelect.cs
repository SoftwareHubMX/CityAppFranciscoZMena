using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Collections.Generic;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys.Select
{
    public class CaracteristicasLugarTuristicoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<CaracteristicaLugarTuristico> SelectCityApp = new SelectCityApp<CaracteristicaLugarTuristico>();

        public CaracteristicasLugarTuristicoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<CaracteristicaLugarTuristico>> SelectCatacteristicasLugarTuristicoIdLugarTuristico(int idLugarTuristico)
        {
            Response<IEnumerable<CaracteristicaLugarTuristico>> response = new Response<IEnumerable<CaracteristicaLugarTuristico>>();

            try
            {
                response.Data = CityAppContext.CaracteristicasLugaresTuristicos.Where(d => d.IdLugarTuristico == idLugarTuristico);

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
