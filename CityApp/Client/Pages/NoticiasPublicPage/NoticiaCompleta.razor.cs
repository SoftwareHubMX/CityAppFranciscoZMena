using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Pages.NoticiasPublicPage
{
    public partial class NoticiaCompleta
    {
        [Parameter] public int idNoticia { get; set; } = 0;
    }
}
