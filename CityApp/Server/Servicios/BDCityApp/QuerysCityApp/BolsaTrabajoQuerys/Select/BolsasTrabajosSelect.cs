using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.BolsaTrabajoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys.Select
{
    public class BolsasTrabajosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<BolsaTrabajo> SelectCityApp = new SelectCityApp<BolsaTrabajo>();

        private Paginado<BolsaTrabajo> Paginado = new Paginado<BolsaTrabajo>();

        public BolsasTrabajosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<IEnumerable<BolsaTrabajo>> SelectBolsasTrabajos()
        {
            Response<IEnumerable<BolsaTrabajo>> response = new Response<IEnumerable<BolsaTrabajo>>();

            try
            {
                response.Data = CityAppContext.BolsasTrabajos;         
                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }
            return response;
        }

        public Response<IEnumerable<BolsaTrabajo>> SelectBolsaTrabajoFirltoBolsaTrabajo(FiltroBolsaTrabajo filtroBolsaTrabajo)
        {
            Response<IEnumerable<BolsaTrabajo>> response = new Response<IEnumerable<BolsaTrabajo>>();

            try
            {
                response.Data = CityAppContext.BolsasTrabajos;

                if (filtroBolsaTrabajo.IdGiro != 0)
                {
                    response.Data = response.Data.Where(d => d.IdGiro == filtroBolsaTrabajo.IdGiro);
                }
                
                if (filtroBolsaTrabajo.Puesto != "NA")
                {
                    response.Data = response.Data.Where(d => d.Puesto.Contains(filtroBolsaTrabajo.Puesto));
                }
                response.Data = response.Data.OrderByDescending(d => d.IdBolsaTrabajo);
                response.Status = SelectCityApp.ValidarLista(response.Data);

                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroBolsaTrabajo.MaximoElementos, filtroBolsaTrabajo.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
