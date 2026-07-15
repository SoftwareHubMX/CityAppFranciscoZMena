using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CitaEndradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CitaQuerys.Select
{
    public class CitasSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Cita> SelectCityApp = new SelectCityApp<Cita>();

        private Paginado<Cita> Paginado = new Paginado<Cita>();

        public CitasSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<IEnumerable<Cita>> SelectCitas()
        {
            Response<IEnumerable<Cita>> response = new Response<IEnumerable<Cita>>();

            try
            {
                response.Data = CityAppContext.Citas;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }
            return response;
        }

        public Response<IEnumerable<Cita>> SelectCitasFirltoCitas(FiltroCitas filtroCitas)
        {
            Response<IEnumerable<Cita>> response = new Response<IEnumerable<Cita>>();

            try
            {
                response.Data = CityAppContext.Citas;

                if (filtroCitas.IdCuenta != 0)
                {
                    response.Data = response.Data.Where(d => d.IdCuenta == filtroCitas.IdCuenta);
                }
                if (filtroCitas.IdTipoCita != 0)
                {
                    response.Data = response.Data.Where(d => d.IdTipoCita == filtroCitas.IdTipoCita);
                }
                response.Data = response.Data.OrderByDescending(d => d.IdCita);
                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroCitas.MaximoElementos, filtroCitas.Pagina);
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
