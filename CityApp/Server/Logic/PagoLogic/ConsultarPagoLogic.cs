using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusPagoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoPagoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PagoLogic
{
    public class ConsultarPagoLogic
    {
        private PagoQuerys PagoQuerys;
        private TipoPagoQuerys TipoPagoQuerys;
        private EstatusPagoQuerys EstatusPagoQuerys;
        private CuentaQuerys CuentaQuerys;
        private UsuarioQuerys UsuarioQuerys;
        private ContactoQuerys ContactoQuerys;

        private int IdPago;

        public ConsultarPagoLogic(CityAppContext cityAppContext, int idPago)
        {
            PagoQuerys = new PagoQuerys(cityAppContext);
            TipoPagoQuerys = new TipoPagoQuerys(cityAppContext);
            EstatusPagoQuerys = new EstatusPagoQuerys(cityAppContext);
            CuentaQuerys = new CuentaQuerys(cityAppContext);
            UsuarioQuerys = new UsuarioQuerys(cityAppContext);
            ContactoQuerys = new ContactoQuerys(cityAppContext);

            IdPago = idPago;
        }

        public Response<Pago> Consultar()
        {
            Response<Pago> response = new Response<Pago>();
            response = PagoQuerys.SelectPagoIdPago(IdPago);
            if(response.Status.Exito == 1)
            {
                Response<TipoPago> responseTipoPago = new Response<TipoPago>();
                responseTipoPago = TipoPagoQuerys.SelectTipoPago(response.Data.IdTipoPago);
                response.Status = responseTipoPago.Status;
                if(response.Status.Exito == 1)
                {
                    response.Data.TipoPago = new TipoPago();
                    response.Data.TipoPago = responseTipoPago.Data;
                }
                Response<EstatusPago> responseEstatusPago = new Response<EstatusPago>();
                responseEstatusPago = EstatusPagoQuerys.SelectEstatusPagoIdEstatusPago(response.Data.IdEstatusPago);
                response.Status = responseEstatusPago.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data.EstatusPago = new EstatusPago();
                    response.Data.EstatusPago = responseEstatusPago.Data;
                }
                Response<Cuenta> responseCuenta = new Response<Cuenta>();
                responseCuenta = CuentaQuerys.SelectCuentaIdCuenta(response.Data.IdCuenta);
                response.Status = responseCuenta.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data.Cuenta = new Cuenta();
                    response.Data.Cuenta = responseCuenta.Data;
                    Response<Usuario> responseUsuario = new Response<Usuario>();
                    responseUsuario = UsuarioQuerys.SelectUsuarioIdCuenta(response.Data.IdCuenta);
                    response.Status = responseUsuario.Status;
                    if (response.Status.Exito == 1)
                    {
                        response.Data.Cuenta.Usuario = new Usuario();
                        response.Data.Cuenta.Usuario = responseUsuario.Data;
                        response.Data.Cuenta.Usuario.Cuenta = null;
                    }
                    Response<Contacto> responseContacto = new Response<Contacto>();
                    responseContacto = ContactoQuerys.SelectContactoIdCenta(response.Data.IdCuenta);
                    response.Status = responseContacto.Status;
                    if(response.Status.Exito == 1)
                    {
                        response.Data.Cuenta.Contacto = new Contacto();
                        response.Data.Cuenta.Contacto = responseContacto.Data;
                        response.Data.Cuenta.Contacto.Cuenta = null;
                    }
                }
            }
            return response;
        }
    }
}
