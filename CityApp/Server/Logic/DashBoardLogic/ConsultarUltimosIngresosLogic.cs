using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoPagoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DashBoardLogic
{
    public class ConsultarUltimosIngresosLogic
    {
        private PagoQuerys PagoQuerys;
        private CuentaQuerys CuentaQuerys;
        private TipoPagoQuerys TipoPagoQuerys;

        public ConsultarUltimosIngresosLogic(CityAppContext cityAppContext)
        {
            PagoQuerys = new PagoQuerys(cityAppContext);
            CuentaQuerys = new CuentaQuerys(cityAppContext);
            TipoPagoQuerys = new TipoPagoQuerys(cityAppContext);
        }

        public Response<List<UltimoPago>> Consultar()
        {
            Response<List<UltimoPago>> response = new Response<List<UltimoPago>>();
            Response<IEnumerable<Pago>> responsePagos = new Response<IEnumerable<Pago>>();
            responsePagos = PagoQuerys.SelectPagos();
            response.Status = responsePagos.Status;
            if(response.Status.Exito == 1)
            {
                List<Pago> pagosAux = responsePagos.Data.ToList();
                response.Data = new List<UltimoPago>();
                if(pagosAux.Count >= 5)
                {
                    for(int i = 0; i < 5; i++)
                    {
                        UltimoPago ultimoPago = new UltimoPago()
                        {
                            Total = pagosAux[i].Total,
                            Fecha = pagosAux[i].FechaPago,

                        };
                        Response<string> responseNobreUsuario = new Response<string>();
                        responseNobreUsuario = CuentaQuerys.SelectNombreUsuarioIdCuenta(pagosAux[i].IdCuenta);
                        if(responseNobreUsuario.Status.Exito == 1)
                        {
                            ultimoPago.Nombre = responseNobreUsuario.Data;
                        }
                        else
                        {
                            ultimoPago.Nombre = "NA";
                        }
                        Response<TipoPago> responseTipoPago = new Response<TipoPago>();
                        responseTipoPago = TipoPagoQuerys.SelectTipoPago(pagosAux[i].IdTipoPago);
                        if(responseTipoPago.Status.Exito == 1)
                        {
                            ultimoPago.Consepto = responseTipoPago.Data.Pago;
                        }
                        else
                        {
                            ultimoPago.Consepto = "NA";
                        }
                        response.Data.Add(ultimoPago);
                    }
                }
                else
                {
                    foreach(var pagoA in pagosAux)
                    {
                        UltimoPago ultimoPago = new UltimoPago()
                        {
                            Total = pagoA.Total,
                            Fecha = pagoA.FechaPago,

                        };
                        Response<string> responseNobreUsuario = new Response<string>();
                        responseNobreUsuario = CuentaQuerys.SelectNombreUsuarioIdCuenta(pagoA.IdCuenta);
                        if (responseNobreUsuario.Status.Exito == 1)
                        {
                            ultimoPago.Nombre = responseNobreUsuario.Data;
                        }
                        else
                        {
                            ultimoPago.Nombre = "NA";
                        }
                        Response<TipoPago> responseTipoPago = new Response<TipoPago>();
                        responseTipoPago = TipoPagoQuerys.SelectTipoPago(pagoA.IdTipoPago);
                        if (responseTipoPago.Status.Exito == 1)
                        {
                            ultimoPago.Consepto = responseTipoPago.Data.Pago;
                        }
                        else
                        {
                            ultimoPago.Consepto = "NA";
                        }
                        response.Data.Add(ultimoPago);
                    }
                }
                response.Status.Exito = (response.Data.Count > 0) ? 1 : 2;
                response.Status.Mensaje = (response.Data.Count > 0) ? "OK" : "No hay ingresos registrados";
            }

            return response;
        }
    }
}
