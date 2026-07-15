using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys.Select
{
    public class LugarTuristicoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<LugarTuristico> SelectCityApp = new SelectCityApp<LugarTuristico>();

        public LugarTuristicoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<LugarTuristico> SelectLugarTuristicoIdLugarTuristico(int idLugarTuristico)
        {
            Response<LugarTuristico> response = new Response<LugarTuristico>();

            try
            {
                response.Data = CityAppContext.LugaresTuristicos.Where(d => d.IdLugarTuristico == idLugarTuristico).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<LugarTuristico> SelectLugarTuristicoCompletoIdLugarTuristico(int idLugarTuristico)
        {
            Response<LugarTuristico> response = new Response<LugarTuristico>();

            try
            {
                response.Data = (from data in CityAppContext.LugaresTuristicos
                                 orderby data.IdLugarTuristico
                                 where data.IdLugarTuristico == idLugarTuristico
                                 select new LugarTuristico()
                                 {
                                     IdLugarTuristico = data.IdLugarTuristico,
                                     Nombre = data.Nombre,
                                     Telefono = data.Telefono,  
                                     UrlWebFacebook = data.UrlWebFacebook,
                                     Descripcion = data.Descripcion,
                                     FechaFundacionConstruccionApertura = data.FechaFundacionConstruccionApertura,
                                     IdTipoLugarTuristico = data.IdTipoLugarTuristico,
                                     TipoLugarTuristico = data.TipoLugarTuristico,
                                     ArchivosLugarTuristico = data.ArchivosLugarTuristico,
                                     CaracteristicasLugarTuristico = data.CaracteristicasLugarTuristico,
                                     DireccionLugarTuristico = data.DireccionLugarTuristico,
                                 }).FirstOrDefault();

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
