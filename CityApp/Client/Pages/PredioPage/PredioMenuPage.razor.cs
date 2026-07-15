using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Pages.PredioPage
{
    public partial class PredioMenuPage
    {
        [Inject] NavigationManager NavigationManager { get; set; }

        private void IrMenu(int opc)
        {
            if (opc == 0)
            {
                NavigationManager.NavigateTo("/Predios/Predios");
            }
            else if (opc == 1)
            {
                NavigationManager.NavigateTo("/Predios/Historicos");
            }
            else if (opc == 2)
            {
                NavigationManager.NavigateTo("/Predios/Descuentos");
            }
        }
    }
}
