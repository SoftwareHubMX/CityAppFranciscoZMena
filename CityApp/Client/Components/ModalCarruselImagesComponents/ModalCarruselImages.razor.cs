using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.ModalCarruselImagesComponents
{
    public partial class ModalCarruselImages
    {
        [Parameter] public List<string> Archivos { get; set; }
        [Parameter] public string Archivo { get; set; }
        [Parameter] public EventCallback OpenCloseModal { get; set; }

        private string ArchivoView = "";
        private int i = 0;


        public void NextBackImage(int direction)
        {
            int j = Archivos.Count;
            if(direction == 1)
            {
                if(i == j)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            else
            {
                if(i == 0)
                {
                    i = j;
                }
                else
                {
                    i--;
                }
            }
            ArchivoView = Archivos[i];
            StateHasChanged();
        }
    }
}
