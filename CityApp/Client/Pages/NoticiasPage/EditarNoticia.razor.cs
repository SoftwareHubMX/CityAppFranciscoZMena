using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Pages.NoticiasPage
{
    public partial class EditarNoticia
    {
        [Parameter] public int idNoticia { get; set; } = 0;
    }
}
