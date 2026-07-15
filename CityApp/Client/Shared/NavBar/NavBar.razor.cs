using Append.Blazor.Notifications;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardAccesosLogic;
using CityApp.Client.Services.SoketSignalR;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace CityApp.Client.Shared.NavBar
{
    public partial class NavBar
    {
        [Inject] private HttpClient Cliente { get; set; }
 
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] private INotificationService NotificationService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] private SignalRService SignalRService { get; set; }
        
        private Sesion Sesion = new Sesion();
        private Rol Rol = new Rol();

        private bool IsSuported;
        private int IdRol = 0;
        private string submenu = "no_view";

        private string Usuario = "";
        private string NomRol = "";
        private string alerta = "";
        private string exito = "";
        private string exito1 = "";
       

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if(Sesion != null)
            {                
                Usuario = Sesion.NombreUsuario;
                IdRol = Sesion.IdRol;
                await ConsultarRol();
                if (Sesion.IdRol == 2)
                {
                    NavigationManager.NavigateTo("/Upps", true);
                }
                else
                {
                    Response<object> response = await SignalRService.IniciarSoket();
                    if (response.Status.Exito == 1)
                    {
                        SignalRService.EventConectarRespuesta += ConectarRespuesta;
                        SignalRService.EventNotificacionNuevoReporte += NotificacionesReportesCiudadanos;
                        SignalRService.EventRespuestaActualizacionEstatus += ObtenerActualizacionEstatus;
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
            else
            {
                NavigationManager.NavigateTo("/Acceso", true);
            }
        }
        private async Task ConsultarRol()
        {
            Response<Rol> response = new Response<Rol>();
            SelectRol selectRol = new SelectRol(Cliente);
            response = await selectRol.Select(IdRol);
            if(response.Status.Exito == 1)
            {
                Rol = response.Data;
            }
            StateHasChanged();
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
                Body = "Hay un nunevo reporte ciudadano",
                Icon = "https://localhost:7179/Imagenes/SheredImagenes/Logo_CityApp_completo.png",
            };

            await NotificationService.CreateAsync("Reporte ciudadano", options);
        }

        public void ConectarRespuesta(object sender, Response<object> response)
        {
            exito = response.Status.Exito.ToString();
            StateHasChanged();
        }

        public void NotificacionesReportesCiudadanos(object sender, Response<object> response)
        {
            alerta = response.Status.Exception;
            exito1 = response.Status.Mensaje;
            Notificar();
            StateHasChanged();
        }

        public void ObtenerActualizacionEstatus(object sender, Response<int> response)
        {
            
            StateHasChanged();
        }

        private async void SalirSesion()
        {
            await LocalStorage.RemoveItemAsync("sesion");
            Sesion = new Sesion();
            NavigationManager.NavigateTo("/", true);
        }

        private async void openSubMenu()
        {
            if(submenu == "no_view")
            {
                submenu = "";
            }
            else
            {
                submenu = "no_view";
            }
            StateHasChanged();
        }
        
        private async void IrDashBoard()
        {
            NavigationManager.NavigateTo("/DashBoard");
        }
    }
}
