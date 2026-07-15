using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusPagoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoPagoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys;
using CityApp.Server.Servicios.PayServices;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;

namespace CityApp.Server.Logic.PagoLogic
{
    public class CrearPagoLogic
    {
        private PagoQuerys PagoQuerys;
        private TipoPagoQuerys TipoPagoQuerys;
        private EstatusPagoQuerys EstatusPagoQuerys;
        private CuentaQuerys CuentaQuerys;
        private UsuarioQuerys UsuarioQuerys;
        private ContactoQuerys ContactoQuerys;
        
        private PayCard PayCard = new PayCard();

        private PagoTarjeta PagoTarjeta;
        private Pago Pago;

        public CrearPagoLogic(CityAppContext cityAppContext, CrearPago crearPago, int idCuenta)
        {
            PagoQuerys = new PagoQuerys(cityAppContext);
            TipoPagoQuerys = new TipoPagoQuerys(cityAppContext);
            EstatusPagoQuerys = new EstatusPagoQuerys(cityAppContext);
            CuentaQuerys = new CuentaQuerys(cityAppContext);
            UsuarioQuerys = new UsuarioQuerys(cityAppContext);
            ContactoQuerys = new ContactoQuerys(cityAppContext);

            //PagoTarjeta = crearPago;
            Pago = new Pago()
            {
                Total = crearPago.Total,
                IdTipoPago = crearPago.IdTipoPago,
                IdCuenta = idCuenta,
                Folio = crearPago.Folio,
                IdEstatusPago = 1,
            };
        }

        public Response<PagoTarjeta> Crear()
        {
            Response<PagoTarjeta> response = new Response<PagoTarjeta>();

            PagoTarjeta = new PagoTarjeta();
            PagoTarjeta.IdTipoPago = Pago.IdTipoPago;

            Response<object> responseInsertPago = new Response<object>();
            responseInsertPago = PagoQuerys.InsertPago(Pago);
            response.Status = responseInsertPago.Status;
            if(response.Status.Exito == 1)
            {
                Response<Pago> responsePago = new Response<Pago>();
                responsePago = PagoQuerys.SelectLastPago(Pago.IdCuenta, Pago.FechaPago);
                response.Status = responsePago.Status;
                if(response.Status.Exito == 1)
                {
                    PagoTarjeta.Pago = new Pago();
                    PagoTarjeta.Pago = responsePago.Data;
                    PagoTarjeta.Amount = responsePago.Data.Total;
                    PagoTarjeta.IdPago = responsePago.Data.IdPago;
                    Response<TipoPago> responseTipoPago = new Response<TipoPago>();
                    responseTipoPago = TipoPagoQuerys.SelectTipoPago(Pago.IdTipoPago);
                    response.Status = responseTipoPago.Status;
                    if (response.Status.Exito == 1)
                    {
                        PagoTarjeta.Description = "Pago de " + responseTipoPago.Data.Pago;
                    }
                    Response<Cuenta> responseCuenta = new Response<Cuenta>();
                    responseCuenta = CuentaQuerys.SelectCuentaIdCuenta(Pago.IdCuenta);
                    response.Status = responseCuenta.Status;
                    if (response.Status.Exito == 1)
                    {
                        PagoTarjeta.Pago.Cuenta = new Cuenta();
                        PagoTarjeta.Pago.Cuenta = responseCuenta.Data;
                        Response<Usuario> responseUsuario = new Response<Usuario>();
                        responseUsuario = UsuarioQuerys.SelectUsuarioIdCuenta(Pago.IdCuenta);
                        response.Status = responseUsuario.Status;
                        if (response.Status.Exito == 1)
                        {
                            PagoTarjeta.Name = (responseUsuario.Data.Nombre != "NA") ? responseUsuario.Data.Nombre : "NA";
                            PagoTarjeta.LastName = (responseUsuario.Data.Apellidos != "NA") ? responseUsuario.Data.Apellidos : "NA";
                        }
                        Response<Contacto> responseContacto = new Response<Contacto>();
                        responseContacto = ContactoQuerys.SelectContactoIdCenta(Pago.IdCuenta);
                        response.Status = responseContacto.Status;
                        if (response.Status.Exito == 1)
                        {
                            PagoTarjeta.Email = (responseContacto.Data.Correo != "NA") ? responseContacto.Data.Correo : "NA";
                            PagoTarjeta.LastName = (responseContacto.Data.TelefonoOpcion1 != "NA") ? responseContacto.Data.TelefonoOpcion1 : (responseContacto.Data.TelefonoOpcion2 != "NA") ? responseContacto.Data.TelefonoOpcion2 : "NA";
                        }
                    }
                    PagoTarjeta.Pago.Cuenta.Contacto.Cuenta = null;
                    PagoTarjeta.Pago.Cuenta.Usuario.Cuenta = null;
                    response.Data = PagoTarjeta;
                    //Response<PagoTarjeta> responsePagoTarjeta = new Response<PagoTarjeta>();
                    //responsePagoTarjeta = PayCard.Pay(PagoTarjeta);
                    //response.Status = responsePagoTarjeta.Status;
                    //if(response.Status.Exito == 1)
                    //{
                    //    PagoTarjeta = responsePagoTarjeta.Data;
                    //    response.Data = PagoTarjeta.Pago;
                    //    //Response<object> responseUpdatePago = new Response<object>();
                    //    //responseUpdatePago = PagoQuerys.UpdatePago(PagoTarjeta.Pago);
                    //    //response.Status = responseUpdatePago.Status;
                    //}
                }
            }

            return response;
        }
    }
}
