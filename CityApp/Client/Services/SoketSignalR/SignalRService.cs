using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace CityApp.Client.Services.SoketSignalR
{
    public class SignalRService
    {
        public event EventHandler<Response<object>> EventConectarRespuesta;

        public event EventHandler<Response<object>> EventNotificacionNuevoReporte;
        public event EventHandler<Response<object>> EventRespuestaNuevoReporte;

        public event EventHandler<Response<int>> EventNotificacionActualizacionEstatus;
        public event EventHandler<Response<int>> EventRespuestaActualizacionEstatus;

        public event EventHandler<Response<object>> EventRespuestaDesconectar;

        private HubConnection HubConnection;

        public SignalRService(string hubAdress)
        {
            HubConnection = new HubConnectionBuilder()
                .WithUrl(hubAdress)
                .WithAutomaticReconnect(new SignalRretryPolicy())
                .Build();
        }

        public async Task<Response<object>> IniciarSoket()
        {
            //objeto response, respuesta de si se pudo conectar
            Response<object> response = new Response<object>();

            //evalua si se esta desconectado o no
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                //lista de las funciones que puede ejecutar el hub
                HubConnection.On<Response<object>>("ConectarRespuesta", ConectarRespuesta);

                HubConnection.On<Response<object>>("NotificacionNuevoReporte", NotificacionNuevoReporte);
                HubConnection.On<Response<object>>("RespuestaNuevoReporte", RespuestaNuevoReporte);

                HubConnection.On<Response<int>>("NotificacionActualizacionEstatus", NotificacionActualizacionEstatus);
                HubConnection.On<Response<int>>("RespuestaActualizacionEstatus", RespuestaActualizacionEstatus);

                HubConnection.On<Response<object>>("RespuestaDesconectar", RespuestaDesconectar);

                //Intenta conectar repetidamente
                bool conectado = false;
                while (!conectado)
                {
                    try
                    {
                        await HubConnection.StartAsync();
                        conectado = true;
                        response.Status.Exito = 1;
                    }
                    catch (Exception ex)
                    {
                        conectado = false;
                        await Task.Delay(3000);
                        response.Status.Exception = ex.Message;
                        response.Status.Mensaje = "Error";
                    }
                }
            }
            else
            {
                //en caso de ya estar conectado solo retorna el objeto con exito en 1
                response.Status.Exito = 1;
            }

            return response;
        }

        //funciones para ejecutar en el soket
        public async Task Conectar(Peticion<int> peticion)
        {
            await HubConnection.InvokeAsync("Conectar", peticion);
        }
        public async Task NuevoReporte(Peticion<object> peticion)
        {
            await HubConnection.InvokeAsync("NuevoReporte", peticion);
        }
        public async Task ActualizacionEstatus(Peticion<int> peticion)
        {
            await HubConnection.InvokeAsync("ActualizacionEstatus", peticion);
        }
        public async Task Desconectar(Peticion<object> peticion)
        {
            await HubConnection.InvokeAsync("Desconectar", peticion);
        }

        //funciones para suscrivirse
        public async Task ConectarRespuesta(Response<object> response)
        {
            EventConectarRespuesta.Invoke(this, response);
        }

        //Admin
        public async Task NotificacionNuevoReporte(Response<object> response)
        {
            EventNotificacionNuevoReporte.Invoke(this, response);
        }
        //Usuario
        public async Task RespuestaNuevoReporte(Response<object> response)
        {
            EventRespuestaNuevoReporte.Invoke(this, response);
        }

        //Usuario
        public async Task NotificacionActualizacionEstatus(Response<int> response)
        {
            EventNotificacionActualizacionEstatus.Invoke(this, response);
        }
        //Admin
        public async Task RespuestaActualizacionEstatus(Response<int> response)
        {
            EventRespuestaActualizacionEstatus.Invoke(this, response);
        }

        public async Task RespuestaDesconectar(Response<object> response)
        {
            EventRespuestaDesconectar.Invoke(this, response);
        }

        //ejecutar siempre que se quiera desconectar o detener el servicio
        public async Task DetenerServicio()
        {
            if (HubConnection.State != HubConnectionState.Disconnected)
            {
                await HubConnection.StopAsync();
                await HubConnection.DisposeAsync();
            }
        }
    }
}
