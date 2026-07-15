using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys.Select
{
    public class ArchivoLugarTuristicoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoLugarTuristico> SelectCityApp = new SelectCityApp<ArchivoLugarTuristico>();

        public ArchivoLugarTuristicoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<ArchivoLugarTuristico> SelectArchivoLugarTuristicoIdArchivoLugarTuristico(int idArchivoLugarTuristico)
        {
            Response<ArchivoLugarTuristico> response = new Response<ArchivoLugarTuristico>();

            try
            {
                response.Data = CityAppContext.ArchivosLugaresTuristicos.Where(d => d.IdArchivoLugarTuristico == idArchivoLugarTuristico).First();

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
