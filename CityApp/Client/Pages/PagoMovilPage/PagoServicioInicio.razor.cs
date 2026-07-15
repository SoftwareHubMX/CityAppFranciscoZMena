using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Pages.PagoMovilPage
{
    public partial class PagoServicioInicio
    {
        [Parameter] public int IdTipoPago { get; set; }
        [Parameter] public int IdObjeto { get; set; }
        [Parameter] public string Token { get; set; }
    }
}
