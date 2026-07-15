using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys.Select
{
    public class ArchivoNoticiaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoNoticia> SelectCityApp = new SelectCityApp<ArchivoNoticia>();

        public ArchivoNoticiaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<ArchivoNoticia> SelectArchivoNoticiaIdArchivoNoticia(int idArchivoNoticia)
        {
            Response<ArchivoNoticia> response = new Response<ArchivoNoticia>();

            try
            {
                response.Data = CityAppContext.ArchivosNoticia.Where(d => d.IdArchivoNoticia == idArchivoNoticia).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<ArchivoNoticia> SelectArchivoNoticiaIdNoticiaPrincipal(int idNoticia)
        {
            Response<ArchivoNoticia> response = new Response<ArchivoNoticia>();

            try
            {
                response.Data = (from data in CityAppContext.ArchivosNoticia
                                where data.IdNoticia == idNoticia
                                && data.Principal == true
                                select new ArchivoNoticia()
                                {
                                    IdArchivoNoticia = data.IdNoticia,
                                    Ruta = data.Ruta,
                                    Formato = data.Formato,
                                    Principal = data.Principal,
                                    IdNoticia = data.IdNoticia,
                                    Noticia = null,
                                }).First();
                    

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<ArchivoNoticia> SelectArchivoNoticiaIdNoticiaFirst(int idNoticia)
        {
            Response<ArchivoNoticia> response = new Response<ArchivoNoticia>();

            try
            {
                response.Data = (from data in CityAppContext.ArchivosNoticia
                                 where data.IdNoticia == idNoticia
                                 select new ArchivoNoticia()
                                 {
                                     IdArchivoNoticia = data.IdNoticia,
                                     Ruta = data.Ruta,
                                     Formato = data.Formato,
                                     Principal = data.Principal,
                                     IdNoticia = data.IdNoticia,
                                     Noticia = null,
                                 }).First();

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
