using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys.Select
{
    public class PrediosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Predio> SelectCityApp = new SelectCityApp<Predio>();

        private Paginado<Predio> Paginado = new Paginado<Predio>();

        public PrediosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Predio>> SelectPrediosFiltros(FiltroPredios filtroPredios)
        {
            Response<IEnumerable<Predio>> response = new Response<IEnumerable<Predio>>();

            try
            {
                response.Data = CityAppContext.Predios.
                    Where(d => (filtroPredios.Clave != "NA") ?
                        d.Clave == filtroPredios.Clave : true
                    && (filtroPredios.ClaveCatastral != "NA") ?
                        d.ClaveCatastral == filtroPredios.ClaveCatastral : true
                    && (filtroPredios.Usuario != "NA") ?
                        (d.Propietario == filtroPredios.Usuario) : true
                    && (filtroPredios.Direccion != "NA") ?
                        d.Direccion == filtroPredios.Direccion : true);

                response.Status = SelectCityApp.ValidarLista(response.Data);

                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroPredios.MaximoNoticias, filtroPredios.Pagina);
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
