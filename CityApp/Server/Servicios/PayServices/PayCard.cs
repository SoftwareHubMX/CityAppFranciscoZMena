using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using static MudBlazor.Icons;

namespace CityApp.Server.Servicios.PayServices
{
    public class PayCard
    {
        private Codificador codificador = new Codificador();

        public Response<PagoTarjeta> Pay(PagoTarjeta pagoTarjeta)
        {
            Response<PagoTarjeta> response = new Response<PagoTarjeta>();
            try
            {
                OpenpayAPI api = new OpenpayAPI("sk_95e13474501c4aa680a2693d5596e3a7", "md7tjkzkt3t5hvivh4yj");

                Customer customer = new Customer();
                customer.Name = (pagoTarjeta.Name != "NA")? codificador.Decrypt(pagoTarjeta.Name) : "NA" ;
                customer.LastName = (pagoTarjeta.LastName != "NA") ? codificador.Decrypt(pagoTarjeta.LastName) : "NA"; ;
                customer.PhoneNumber = (pagoTarjeta.PhoneNumber != "NA") ? codificador.Decrypt(pagoTarjeta.PhoneNumber) : "NA";
                customer.Email = (pagoTarjeta.Email != "NA") ? codificador.DecryptCorreo(pagoTarjeta.Email) : "NA";

                ChargeRequest request = new ChargeRequest();
                request.Method = "card";
                request.SourceId = pagoTarjeta.TokenId;
                request.Amount = new Decimal(pagoTarjeta.Amount);
                request.Description = pagoTarjeta.Description;
                request.DeviceSessionId = pagoTarjeta.DeviceSessionId;
                request.Customer = customer;

                // Opcional, si estamos usando puntos
                //request.UseCardPoints = useCardPoints;

                Charge charge = api.ChargeService.Create(request);



                response.Status.Mensaje = (charge.Status == "complited")? "OK" : charge.ErrorMessage;
                response.Status.Exito = (charge.Status == "completed") ? 1 : 2;
                if(response.Status.Exito == 1)
                {
                    pagoTarjeta.Pago.Referencia = charge.Authorization;
                    pagoTarjeta.Pago.Identificador = charge.Id;
                    pagoTarjeta.Pago.FechaPago = charge.CreationDate.Value;
                    pagoTarjeta.Pago.IdEstatusPago = 2;
                }
                else
                {
                    pagoTarjeta.Pago.IdEstatusPago = 3;
                }
                response.Data = pagoTarjeta;
            }
            catch (Exception e)
            {
                response.Status.Exception = e.Message;
                response.Status.Mensaje = "Error al realizar el cobro";
                response.Status.Exito = 0;
            }
            return response;
        }
    }
}
