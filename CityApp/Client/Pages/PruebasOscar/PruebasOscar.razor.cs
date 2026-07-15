using Append.Blazor.Notifications;
using Blazored.LocalStorage;
using CityApp.Client.MVComponents.OpenPayMVComponents;
using CityApp.Client.Services.SoketSignalR;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace CityApp.Client.Pages.PruebasOscar
{
    public partial class PruebasOscar : IAsyncDisposable
    {
        [Inject] private INotificationService NotificationService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] private SignalRService SignalRService { get; set; }

        private static MVGetDataPay MVGetDataPay = new MVGetDataPay();
        private bool IsSuported;

        private Sesion Sesion = new Sesion();

        private string alerta = "";
        private string exito = "";
        private string exito1 = "";


        protected override async Task OnInitializedAsync()
        {
            MVGetDataPay.metodoAlQueSeSuscrive += EjecucionStaticDinamic;
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if(Sesion != null)
            {
                Response<object> response = await SignalRService.IniciarSoket();
                if (response.Status.Exito == 1)
                {
                    SignalRService.EventConectarRespuesta += ConectarRespuesta;
                    SignalRService.EventNotificacionActualizacionEstatus += NotificarActualizacionEstatus;
                    SignalRService.EventRespuestaNuevoReporte += ObtenerRespuestaNuevoReporte;
                }
                try
                {
                    conectar();
                }
                catch (Exception ex)
                {
                    alerta = ex.Message;
                }
                IsSuported = await NotificationService.IsSupportedByBrowserAsync();
                if (IsSuported)
                {
                    await NotificationService.RequestPermissionAsync();
                }
            }
        }

        private void conectar()
        {
            Peticion<int> peticion = new Peticion<int>()
            {
                Data = Sesion.IdCuenta,
            };
            SignalRService.Conectar(peticion);
        }

        private async void Notificar()
        {
            NotificationOptions options = new NotificationOptions
            {
                Body = "Su reporte fue atendido",
                Icon = "https://localhost:7179/Imagenes/SheredImagenes/Logo_CityApp_completo.png",
            };

            await NotificationService.CreateAsync("Reporte ciudadano", options);
        }

        public void ConectarRespuesta(object sender, Response<object> response)
        {
            exito = response.Status.Exito.ToString();
            StateHasChanged();
        }

        public void ObtenerRespuestaNuevoReporte(object sender, Response<object> response)
        {
            alerta = response.Status.Exception;
            exito1 = response.Status.Mensaje;
            StateHasChanged();
        }

        public void NotificarActualizacionEstatus(object sender, Response<int> response)
        {

            Notificar();
            StateHasChanged();
        }

        
        private void MandarReporte()
        {
            Peticion<object> peticion = new Peticion<object>();
            SignalRService.NuevoReporte(peticion);
        }

        [Inject] private HttpClient Cliente { get; set; }
        [Inject] IJSRuntime jsRuntime { get; set; }
        IJSObjectReference modulo;
        //IJSObjectReference lib;
        //IJSObjectReference lib2;
        private bool banderaTokenizacion = false;
        private string deviceIdHiddenFieldName = "";
        private string tokenId = "";

        protected override async Task OnAfterRenderAsync(bool firtsRender)
        {
            if (firtsRender)
            {
                //lib = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "https://resources.openpay.mx/lib/openpay-js/1.2.38/openpay.v1.min.js");
                //lib2 = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "https://resources.openpay.mx/lib/openpay-data-js/1.2.38/openpay-data.v1.min.js");
                modulo = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "../Js/PayJs/OpenPay.js"); 
                await modulo.InvokeVoidAsync("openPayActions");
            }
            else
            {
                if (!banderaTokenizacion)
                {
                    if(deviceIdHiddenFieldName != "")
                    {
                        if(tokenId != "")
                        {
                            banderaTokenizacion = true;
                            RealizarCobro();
                        }
                    }
                }
            }
        }

        private async void EjecucionStaticDinamic(object sender, (string, string) data)
        {
            tokenId = data.Item1;
            deviceIdHiddenFieldName = data.Item2;
            StateHasChanged();
        }

        [JSInvokable("GetDataPay")]
        public static void GetDataPay(string idToken, string deviceName)
        {
            MVGetDataPay.ejecutar(idToken, deviceName);
        }

        private void TxtDevices(ChangeEventArgs args)
        {
            deviceIdHiddenFieldName = args.Value.ToString();
            StateHasChanged();
        }

        private void TxtTokenId(ChangeEventArgs args)
        {
            tokenId = args.Value.ToString();
            StateHasChanged();
        }

        private async void RealizarCobro()
        {
            CrearPago crearPago = new CrearPago()
            {
                FechaPago = DateTime.UtcNow.AddHours(-6),
                Total =10,
                IdTipoPago = 1,
            };
            Response<Pago> response = new Response<Pago>();
            string url = "Pago/CrearPago";
            Peticion<CrearPago> peticion = new Peticion<CrearPago>();
            peticion.Token = Sesion.TokenAcceso;
            peticion.Data = crearPago;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<CrearPago>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Pago>>().Result;
            }
            else
            {
                response.Status.Mensaje = "Error: "
                    + "\n Status: " + responsePeticion.StatusCode.ToString()
                    + "\n Alerta: " + responsePeticion.ReasonPhrase;
            }

            if(response.Status.Exito == 1)
            {
                Pay(response.Data);
            }
            else
            {
                alerta = response.Status.Mensaje + "</br>" + response.Status.Exception;
            }
            StateHasChanged();
        }

        private async void Pay(Pago pago)
        {
            PagoTarjeta pagoTarjeta = new PagoTarjeta()
            {
                DeviceSessionId = deviceIdHiddenFieldName,
                TokenId = tokenId,
                Name = "Oscar Alexei",
                LastName = "Ramiro Mier",
                Email = "osalrami.97@gmail.com",
                PhoneNumber = "4831004507",
                Amount = 10,
                Description = "Pago de servicio de prueba",
                IdTipoPago = 1,
                Pago = pago,
            };
            Response<Pago> response = new Response<Pago>();
            string url = "Pay/RealizarPago";
            Peticion<PagoTarjeta> peticion = new Peticion<PagoTarjeta>();
            peticion.Token = Sesion.TokenAcceso;
            peticion.Data = pagoTarjeta;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<PagoTarjeta>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Pago>>().Result;
            }
            else
            {
                response.Status.Mensaje = "Error: "
                    + "\n Status: " + responsePeticion.StatusCode.ToString()
                    + "\n Alerta: " + responsePeticion.ReasonPhrase;
            }

            if (response.Status.Exito == 1)
            {
                ActualizarPago(response.Data);
            }
            else
            {
                alerta = response.Status.Mensaje + "</br>" + response.Status.Exception;
            }
            StateHasChanged();
        }

        private async void ActualizarPago(Pago pago)
        {
            Response<object> response = new Response<object>();
            string url = "Pago/ActualizarPago";
            Peticion<Pago> peticion = new Peticion<Pago>();
            peticion.Token = Sesion.TokenAcceso;
            peticion.Data = pago;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Pago>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<object>>().Result;
            }
            else
            {
                response.Status.Mensaje = "Error: "
                    + "\n Status: " + responsePeticion.StatusCode.ToString()
                    + "\n Alerta: " + responsePeticion.ReasonPhrase;
            }

            if (response.Status.Exito == 1)
            {
                alerta = "cobro realizado con exito";
            }
            else
            {
                alerta = response.Status.Mensaje + "</br>" + response.Status.Exception;
            }
            StateHasChanged();
        }

        public async Task<Response<string>> EnviarCorreoAsync(string c, string d)
        {
            Response<string> response = new Response<string>();

            string url = "EnviarCorreo/EnviarCorreoA";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Identificador = c;
            peticion.Data = d;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<string>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<string>>().Result;
            }
            else
            {
                response.Status.Mensaje = "Error: "
                    + "\n Status: " + responsePeticion.StatusCode.ToString()
                    + "\n Alerta: " + responsePeticion.ReasonPhrase;
            }

            return response;
        }

        private async void CreateCard()
        {
            await modulo.InvokeVoidAsync("openPayActions");
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            if (modulo != null)
            {
                await modulo.DisposeAsync();
                //await lib.DisposeAsync();
                //await lib2.DisposeAsync();
            }
        }
    }
}
