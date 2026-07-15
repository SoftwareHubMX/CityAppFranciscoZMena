using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Pages.BolsaTrabajoPostulacionPage
{
    public partial class BolsaTrabajoPostulacionInicioPage
    {
        [Inject] NavigationManager NavigationManager { get; set; }

        private void IrMenu(int opc)
        {
            if (opc == 0)
            {
                NavigationManager.NavigateTo("/BolsaTrabajos/BolsasTrabajos");
            }
            else if (opc == 1)
            {
                NavigationManager.NavigateTo("/BolsaTrabajos/Postulaciones");
            }
            
        }
    }
}
