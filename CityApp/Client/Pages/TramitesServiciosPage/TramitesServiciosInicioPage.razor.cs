using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Pages.TramitesServiciosPage
{
    public partial class TramitesServiciosInicioPage
    {
        [Inject] NavigationManager NavigationManager { get; set; }

        private void IrMenu(int opc)
        {
            if(opc == 0)
            {
                NavigationManager.NavigateTo("/TramitesServicios/Secretarias");
            }
            else if (opc == 1)
            {
                NavigationManager.NavigateTo("/TramitesServicios/Dependencias");
            }
            else if(opc == 2)
            {
                NavigationManager.NavigateTo("/TramitesServicios/Tramites");
            }
        }
    }
}
