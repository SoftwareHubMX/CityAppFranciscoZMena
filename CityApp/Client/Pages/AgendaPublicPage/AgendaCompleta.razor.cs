using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Pages.AgendaPublicPage
{
    public partial class AgendaCompleta
    {
        [Parameter] public int idAgenda { get; set; } = 0;
    }
}
