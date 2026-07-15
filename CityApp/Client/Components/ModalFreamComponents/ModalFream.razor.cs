using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.ModalFreamComponents
{
    public partial class ModalFream
    {
        [Parameter] public string Archivo { get; set; } = "";
        [Parameter] public EventCallback OpenCloseModal { get; set; }

        private string rutaBase = "https://docs.google.com/gview?url=https://www.cityapp.mx/";

        protected override async Task OnInitializedAsync()
        {
            rutaBase += Archivo + "&embedded=true";
        }
    }
}
