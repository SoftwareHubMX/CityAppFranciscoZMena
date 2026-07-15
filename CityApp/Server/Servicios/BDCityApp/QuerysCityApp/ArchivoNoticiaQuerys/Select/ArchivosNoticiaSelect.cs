using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys.Select
{
    public class ArchivosNoticiaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoNoticia> SelectCityApp = new SelectCityApp<ArchivoNoticia>();

        public ArchivosNoticiaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<ArchivoNoticia>> SelectArchivosNoticiaIdNoticia(int idNoticia)
        {
            Response<IEnumerable<ArchivoNoticia>> response = new Response<IEnumerable<ArchivoNoticia>>();

            try
            {
                response.Data = from data in CityAppContext.ArchivosNoticia
                                where data.IdNoticia == idNoticia
                                select new ArchivoNoticia()
                                {
                                    IdArchivoNoticia = data.IdArchivoNoticia,
                                    Ruta = data.Ruta,
                                    Formato = data.Formato,
                                    Principal = data.Principal,
                                    IdNoticia = data.IdNoticia
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
