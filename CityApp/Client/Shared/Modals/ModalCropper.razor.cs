using Blazor.Cropper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CityApp.Client.Shared.Modals
{
    public partial class ModalCropper
    {
        [Parameter] public EventCallback<MultipartFormDataContent> GuardarImagen { get; set; }
        [Parameter] public int Id { get; set; } = 1;
        [Parameter] public int AspectWidth { get; set; } = 0;
        [Parameter] public int AspectHeight { get; set; } = 0;
        [Inject] HttpClient HttpClient { get; set; }

        private bool guardado = false;
        private string idFile = "";
        private bool banderaIdFile = false;

        private double widthCalc = 10;
        private double heightCalc = 10;

        //objetos de la libreria
        private Cropper cropper; //cortador
        private CropInfo state; //estatus actual del corte

        //Archivo
        private IBrowserFile file;

        //valores de configuracion de la libreria
        private double width;
        private double height;
        private bool show = true;
        private bool parsing = false;
        private double ratio = 1;
        private int offsetx;
        private int offsety;

        //Establecen el tamaño inicial del cuadrito de recorte
        private double InitW = 144;
        private double InitH = 81;


        protected override async Task OnInitializedAsync()
        {
            if (AspectWidth > 0 && AspectHeight > 0)
            {
                widthCalc = widthCalc * AspectWidth;
                heightCalc = heightCalc * AspectHeight;
                InitW = widthCalc;
                InitH = heightCalc;
            }
            else
            {
                widthCalc = 144;
                heightCalc = 81;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                if (!banderaIdFile)
                {
                    if (Id > 0)
                    {
                        if (idFile == "")
                        {
                            idFile = "input" + Id;
                        }
                    }
                    banderaIdFile = true;
                    StateHasChanged();
                }
            }
        }

        
        //Carga del archivo
        private async Task OnInputFileChange(InputFileChangeEventArgs args)
        {
            file = args.File;
            StateHasChanged();
        }

        //Ajusta el zoom de la imagen
        private void OnRatioChange(ChangeEventArgs args)
        {
            ratio = int.Parse(args.Value.ToString()) / 100.0;
        }

        //realiza el corte
        private async Task DoneCrop()
        {
            guardado = true;
            var args = await cropper.GetCropedResult();
            parsing = true;
            base.StateHasChanged();
            await Task.Delay(10);
            var arrayImg = await args.GetDataAsync();

            //cargar el resultado a una api
            MemoryStream ms = new MemoryStream(arrayImg, 0, arrayImg.Length);
            var content = new MultipartFormDataContent();
            content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data");
            content.Add(new StreamContent(ms, arrayImg.Length), "file", "imagen.png");
            await GuardarImagen.InvokeAsync(content);
            ms.Dispose();//importante sacar de memoria el stream
            parsing = false;
            guardado = false;
            cancelar();
        }

        private void cancelar()
        {
            offsetx = 0;
            offsety = 0;
            InitW = widthCalc;
            InitH = heightCalc;
            file = null;
            StateHasChanged();
        }
    }
}
