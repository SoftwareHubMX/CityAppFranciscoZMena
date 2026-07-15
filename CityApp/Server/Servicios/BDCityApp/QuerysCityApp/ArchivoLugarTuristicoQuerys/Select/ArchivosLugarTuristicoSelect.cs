using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys.Select
{
    public class ArchivosLugarTuristicoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoLugarTuristico> SelectCityApp = new SelectCityApp<ArchivoLugarTuristico>();

        public ArchivosLugarTuristicoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<ArchivoLugarTuristico>> SelectArchivosLugarTuristicoIdLugarTuristico(int idLugarTuristico)
        {
            Response<IEnumerable<ArchivoLugarTuristico>> response = new Response<IEnumerable<ArchivoLugarTuristico>>();

            try
            {
                response.Data = from data in CityAppContext.ArchivosLugaresTuristicos
                                where data.IdLugarTuristico == idLugarTuristico
                                select new ArchivoLugarTuristico()
                                {
                                    IdArchivoLugarTuristico = data.IdArchivoLugarTuristico,
                                    Ruta = data.Ruta,
                                    Formato = data.Formato,
                                    FechaArchivo = data.FechaArchivo,
                                    IdLugarTuristico = data.IdLugarTuristico
                                };

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
