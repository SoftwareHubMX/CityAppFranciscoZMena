using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys.Select
{
    public class CuentasSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Cuenta> SelectCityApp = new SelectCityApp<Cuenta>();
        private Paginado<Cuenta> Paginado = new Paginado<Cuenta>();

        public CuentasSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Cuenta>> SelectCuentas()
        {
            Response<IEnumerable<Cuenta>> response = new Response<IEnumerable<Cuenta>>();

            try
            {
                response.Data = CityAppContext.Cuentas.Where(d => d.IdRol == 7).OrderBy(d => d.IdCuenta);

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
        
        public Response<IEnumerable<Cuenta>> SelectCuentasFiltroCuentas(FiltroCuentas filtroCuentas)
        {
            Response<IEnumerable<Cuenta>> response = new Response<IEnumerable<Cuenta>>();
            try
            {
                response.Data = from data in CityAppContext.Cuentas
                                orderby data.IdCuenta
                                select new Cuenta()
                                {
                                    IdCuenta = data.IdCuenta,
                                    NombreUsuario = data.NombreUsuario,
                                    IdRol = data.IdRol,
                                    FechaRegistro = data.FechaRegistro,
                                    Rol = data.Rol,
                                    Usuario = data.Usuario,
                                    Contacto = data.Contacto,
                                };
                if (filtroCuentas.IdCuenta != 0)
                {
                    response.Data = response.Data.Where(d => d.IdCuenta == filtroCuentas.IdCuenta);
                }
                if (filtroCuentas.IdRol != 0)
                {
                    response.Data = response.Data.Where(d => d.IdRol == filtroCuentas.IdRol);
                }
                response.Data = response.Data.OrderByDescending(d => d.IdCuenta);
                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroCuentas.MaximoElementos, filtroCuentas.Pagina);
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
