using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Pages.AgendasPage
{
    public partial class EditarAgenda
    {
        [Parameter] public int idAgenda { get; set; } = 0;
    }
}
