using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CityApp.Client.Shared.Modals
{
    public partial class ModalCropperCompleto
    {
        [Parameter] public EventCallback<MultipartFormDataContent> GuardarImagen { get; set; }
        [Parameter] public int Id { get; set; } = 1;
        [Inject] HttpClient HttpClient { get; set; }
        [Parameter] public int AspectWidth { get; set; } = 0;//AGREGUE
        [Parameter] public int AspectHeight { get; set; } = 0;

        private bool guardado = false;
        private string idFile = "";
        private bool banderaIdFile = false;

        //Archivo
        private IBrowserFile file;
        private string previewUrl;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                if (!banderaIdFile)
                {
                    if (Id > 0 && idFile == "")
                    {
                        idFile = "input" + Id;
                    }
                    banderaIdFile = true;
                    StateHasChanged();
                }
            }
        }

        // Carga del archivo y genera preview
        private async Task OnInputFileChange(InputFileChangeEventArgs args)
        {
            file = args.File;

            using var stream = file.OpenReadStream();
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            var bytes = ms.ToArray();
            previewUrl = $"data:{file.ContentType};base64,{Convert.ToBase64String(bytes)}";

            StateHasChanged();
        }

        // Subir imagen tal cual (reemplaza DoneCrop)
        private async Task DoneCrop()
        {
            guardado = true;

            var stream = file.OpenReadStream();
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(stream, (int)file.Size), "file", file.Name);

            await GuardarImagen.InvokeAsync(content);

            guardado = false;
            cancelar();
        }

        private void cancelar()
        {
            file = null;
            previewUrl = null;
            StateHasChanged();
        }
    }
}
