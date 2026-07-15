using Blazored.LocalStorage;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Shared.BarMenu
{
    public partial class BarMenu
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }

        private Sesion Sesion = new Sesion();
        private int idRol = 0;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                idRol = Sesion.IdRol;
                StateHasChanged();
            }
        }

        private string openClose = "";
        private string icono = "chevron-left";

        private async void OpenCloseMenu()
        {
            if(openClose == "")
            {
                openClose = "close";
                icono = "menu";
            }
            else
            {
                openClose = "";
                icono = "chevron-left";
            }
            StateHasChanged();
        }

        private async void IrPage(int page)
        {
            if(page == 1)
            {
                NavigationManager.NavigateTo("/ReporteCiudadano");
            }
            else if(page == 2)
            {
                NavigationManager.NavigateTo("/Noticias");
            }
            else if (page == 3)
            {
                NavigationManager.NavigateTo("/Predios");
            }
            else if (page == 4)
            {
                NavigationManager.NavigateTo("/Pagos");
            }
            else if (page == 5)
            {
                NavigationManager.NavigateTo("/Eventos");
            }
            else if (page == 6)
            {
                NavigationManager.NavigateTo("/Turismo");
            }
            else if (page == 7)
            {
                NavigationManager.NavigateTo("/Alertas");
            }
            else if (page == 8)
            {
                NavigationManager.NavigateTo("/SeguridadPublica");
            }
            else if (page == 9)
            {
                NavigationManager.NavigateTo("/ContactoMunicipio");
            }
            else if (page == 10)
            {
                NavigationManager.NavigateTo("/MultimediaApp");
            }
            else if (page == 11)
            {
                NavigationManager.NavigateTo("/TramitesServicios");
            }
            else if (page == 12)
            {
            NavigationManager.NavigateTo("/Directorios");
            }
            else if (page == 13)
            {
                NavigationManager.NavigateTo("/BolsaTrabajos");
            }
            else if (page == 14)
            {
                NavigationManager.NavigateTo("/RutasRecolecciones");
            }
            else if (page == 15)
            {
                NavigationManager.NavigateTo("/Anuncios");
            }
            else if (page == 16)
            {
                NavigationManager.NavigateTo("/Citas");
            }
        }
    }
}
