using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Pages.SeguridadPublicaPage
{
    public partial class SeguridadPublicaInicio
    {
        [Inject] NavigationManager NavigationManager { get; set; }

        private void IrMenu(int opc)
        {
            if(opc == 0)
            {
                NavigationManager.NavigateTo("/SeguridadPublica/Citas");
            }
            else if (opc == 1)
            {
                NavigationManager.NavigateTo("/SeguridadPublica/Normatividades");
            }
            else if(opc == 2)
            {
                NavigationManager.NavigateTo("/SeguridadPublica/ContactosSeguridadPublica");
            }
        }
    }
}
