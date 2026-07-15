using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys.Select
{
    public class TramiteSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Tramite> SelectCityApp = new SelectCityApp<Tramite>();

        public TramiteSelect (CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<Tramite> SelectTramiteIdTramite(int idTramite)
        {
            Response<Tramite> response = new Response<Tramite>();

            try
            {
                response.Data = CityAppContext.Tramites.Where(d =>d.IdTramite == idTramite).First();
                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }
            return response;
        }

        public Response<Tramite> SelectTramiteIdTramiteCompleto(int idTramite)
        {
            Response<Tramite> response = new Response<Tramite>();

            try
            {
                response.Data = (from data in CityAppContext.Tramites
                                 where data.IdTramite == idTramite
                                 select new Tramite
                                 {
                                     IdTramite = data.IdTramite,
                                     Concepto = data.Concepto,
                                     Descripcion = data.Descripcion,
                                     Direccion = data.Direccion,
                                     Telefono = data.Telefono,
                                     Requisitos = data.Requisitos,
                                     Observaciones = data.Observaciones,
                                     Costo = data.Costo,
                                     Latitud = data.Latitud,
                                     Longitud = data.Longitud,
                                     IdDependencia = data.IdDependencia,
                                     IdTipoTramite = data.IdTipoTramite,

                                     Dependencia = data.Dependencia != null ? new Dependencia
                                     {
                                         IdDependencia = data.Dependencia.IdDependencia,
                                         NombreDependencia = data.Dependencia.NombreDependencia,
                                         IdSecretaria = data.Dependencia.IdSecretaria,

                                         Secretaria = data.Dependencia.Secretaria != null ? new Secretaria
                                         {
                                             IdSecretaria = data.Dependencia.Secretaria.IdSecretaria,
                                             NombreSecretaria = data.Dependencia.Secretaria.NombreSecretaria,
                                         } : null
                                     } : null,                                    
                                 }).FirstOrDefault();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }
            return response;
        }


        public Response<Tramite> SelectTramiteIdTipoTramite(int idTipoTramite)
        {
            Response<Tramite> response = new Response<Tramite>();

            try
            {
                response.Data = CityAppContext.Tramites.Where(d => d.IdTipoTramite == idTipoTramite).FirstOrDefault();
                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch(Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }
            return response;
        }
    }




}
