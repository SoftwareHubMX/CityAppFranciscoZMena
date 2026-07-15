using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.CardEditarContactoMunicipioLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;

namespace CityApp.Client.Components.CardEditarContactoMunicipioComponents
{
    public partial class CardEditarContactoMunicipio
    {
        [Parameter] public int IdContactoMunicipio { get; set; }
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";


        private Validaciones Validaciones = new Validaciones();

        private Sesion Sesion = new Sesion();

        private ContactoMunicipio ContactoMunicipio = new ContactoMunicipio();
        private ContactoMunicipio ContactoMunicipioNoModificado = new ContactoMunicipio();
        private List<RedSocialMunicipio> RedesSocialesMunicipio = new List<RedSocialMunicipio>();
        private RedSocialMunicipio RedSocialMunicipio = new RedSocialMunicipio();
        private List<TipoRedSocial> TiposRedesSociales = new List<TipoRedSocial>();

        //private string busqueda = "";
        private string direccion = "";
        private string telefono = "";
        private string web = "";
        private string horario = "";
        private string usuarioRed = "";
        private int idTipoRedSocial = 0;
        private string direccionError = "";
        private string telefonoError = "";
        private string webError = "";
        private string horarioError = "";
        private string usuarioRedError = "";
        private string idTipoRedSocialError = "";

        private string section1 = "";
        private string section2 = "no_view";

        private string alerta = "";

        protected override async Task OnInitializedAsync()
        {
            ConsultarTiposRedesSociales();
        }

        protected override async Task OnAfterRenderAsync(bool firtsRender)
        {
            if (firtsRender)
            {
                archivoIdioma = await LocalStorage.GetItemAsync<string>("Language");

                if (archivoIdioma != null)
                {
                    ViewString.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(archivoIdioma));
                }
                else
                {
                    archivoIdioma = "es-MX";
                    ViewString.SetLanguage(System.Globalization.CultureInfo.GetCultureInfo(archivoIdioma));
                    await LocalStorage.SetItemAsync<string>("Language", archivoIdioma);
                }
                Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
                if(Sesion != null)
                {
                    ConsultarContactoMunicipio();
                }
                StateHasChanged();
            }
        }

        private async void ConsultarTiposRedesSociales()
        {
            Response<List<TipoRedSocial>> response = new Response<List<TipoRedSocial>>();
            SelectTiposRedesSociales selectTiposRedesSociales = new SelectTiposRedesSociales(Cliente);
            response = await selectTiposRedesSociales.SelectAll();
            if (response.Status.Exito == 1)
            {
                TiposRedesSociales = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void ConsultarContactoMunicipio()
        {
            Response<ContactoMunicipio> response = new Response<ContactoMunicipio>();
            SelectContactoMunicipioId selectContactoMunicipioId = new SelectContactoMunicipioId(Cliente);
            response = await selectContactoMunicipioId.Select(Sesion.TokenAcceso, IdContactoMunicipio);
            if(response.Status.Exito == 1)
            {
                ContactoMunicipio = response.Data;
                ContactoMunicipioNoModificado = response.Data;
                direccion = ContactoMunicipio.Direccion;
                web = ContactoMunicipio.Web;
                horario = ContactoMunicipio.Horario;
                telefono = ContactoMunicipio.Telefono;
                RedesSocialesMunicipio = ContactoMunicipio.RedesSocialesMunicipio;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void ActualizarContacto()
        {
            if (ContactoMunicipio.Web == ContactoMunicipioNoModificado.Web && ContactoMunicipio.Direccion == ContactoMunicipioNoModificado.Direccion && ContactoMunicipio.Telefono == ContactoMunicipioNoModificado.Telefono && ContactoMunicipio.Horario == ContactoMunicipioNoModificado.Horario)
            {
                Guardar();
            }
            else
            {
                Response<object> response = new Response<object>();
                UpdateContactoMunicipio updateContactoMunicipio = new UpdateContactoMunicipio(Cliente);
                response = await updateContactoMunicipio.Update(Sesion.TokenAcceso, ContactoMunicipio);
                if (response.Status.Exito == 1)
                {
                    Guardar();
                }
                else
                {
                    alerta = response.Status.Mensaje;
                }
            }
            StateHasChanged();
        }

        private void TxtDireccion(ChangeEventArgs args)
        {
            direccion = args.Value.ToString();
            if (direccion != "")
            {
                direccionError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(direccion))
                {
                    direccionError = "";
                    ContactoMunicipio.Direccion = direccion;
                }
                else
                {
                    direccionError = "NoCaracteresEspeciales";
                    direccion = "";
                    ContactoMunicipio.Direccion = "NA";
                }
            }

            StateHasChanged();
        }

        private void TxtTelefono(ChangeEventArgs args)
        {
            telefono = args.Value.ToString();
            if (telefono != "")
            {
                telefonoError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(telefono))
                {
                    telefonoError = "";
                    ContactoMunicipio.Telefono = telefono;
                }
                else
                {
                    telefonoError = "NoCaracteresEspeciales";
                    telefono = "";
                    ContactoMunicipio.Telefono = "NA";
                }
            }

            StateHasChanged();
        }

        private void TxtWeb(ChangeEventArgs args)
        {
            web = args.Value.ToString();
            if (web != "")
            {
                webError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(web))
                {
                    webError = "";
                    ContactoMunicipio.Web = web;
                }
                else
                {
                    webError = "NoCaracteresEspeciales";
                    web = "";
                    ContactoMunicipio.Web = "NA";
                }
            }

            StateHasChanged();
        }

        private void TxtHorario(ChangeEventArgs args)
        {
            horario = args.Value.ToString();
            if (horario != "")
            {
                horarioError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(horario))
                {
                    horarioError = "";
                    ContactoMunicipio.Horario = horario;
                }
                else
                {
                    horarioError = "NoCaracteresEspeciales";
                    horario = "";
                    ContactoMunicipio.Horario = "NA";
                }
            }

            StateHasChanged();
        }

        private void TxtUsuariRed(ChangeEventArgs args)
        {
            usuarioRed = args.Value.ToString();
            if (usuarioRed != "")
            {
                usuarioRedError = "";
                StateHasChanged();
                if (Validaciones.ValidarCaracteres(usuarioRed))
                {
                    usuarioRedError = "";
                    RedSocialMunicipio.Ruta = usuarioRed;
                }
                else
                {
                    usuarioRedError = "NoCaracteresEspeciales";
                    usuarioRed = "";
                    RedSocialMunicipio.Ruta = "NA";
                }
            }

            StateHasChanged();
        }

        private void TxtIdTipoRedSocial(ChangeEventArgs args)
        {
            idTipoRedSocial = int.Parse(args.Value.ToString());
            if (idTipoRedSocial != 0)
            {
                idTipoRedSocialError = "";
                RedSocialMunicipio.IdTipoRedSocial = idTipoRedSocial;
            }
            else
            {
                idTipoRedSocialError = "SeleccioneOpcion";
                RedSocialMunicipio.IdTipoRedSocial = 0;
            }

            StateHasChanged();
        }

        private async Task saveRedSocial()
        {
            RedSocialMunicipio.IdContactoMunicipio = ContactoMunicipio.IdContactoMunicipio;
            if (RedSocialMunicipio.IdTipoRedSocial != 0)
            {
                if (RedSocialMunicipio.Ruta != "NA")
                {
                    Response<int> response = new Response<int>();
                    InsertRedSocialMunicipio insertRedSocialMunicipio = new InsertRedSocialMunicipio(Cliente);
                    response = await insertRedSocialMunicipio.Insert(Sesion.TokenAcceso, RedSocialMunicipio);
                    if (response.Status.Exito == 1)
                    {
                        RedSocialMunicipio red = new RedSocialMunicipio()
                        {
                            IdContactoMunicipio = ContactoMunicipio.IdContactoMunicipio,
                            Ruta = RedSocialMunicipio.Ruta,
                            IdTipoRedSocial = RedSocialMunicipio.IdTipoRedSocial,
                            IdRedSocialMunicipio = response.Data
                        };
                        foreach (var redSocial in TiposRedesSociales)
                        {
                            if (redSocial.IdTipoRedSocial == red.IdTipoRedSocial)
                            {
                                red.TipoRedSocial = redSocial;
                            }
                        }
                        RedesSocialesMunicipio.Add(red);
                        RedSocialMunicipio = new RedSocialMunicipio();
                        usuarioRed = "";
                        idTipoRedSocial = 0;
                    }
                    else
                    {
                        alerta = response.Status.Mensaje;
                    }
                }
                else
                {
                    usuarioRedError = "CampoRequerido";
                }
            }
            else
            {
                idTipoRedSocialError = "SeleccioneOpcion";
            }
            StateHasChanged();
        }

        private async void EliminarRed(int idRed)
        {
            Response<object> response = new Response<object>();
            DeleteRedSocialMunicipio deleteRedSocialMunicipio = new DeleteRedSocialMunicipio(Cliente);
            response = await deleteRedSocialMunicipio.Delete(Sesion.TokenAcceso, idRed);
            if (response.Status.Exito == 1)
            {
                List<RedSocialMunicipio> redesAux = new List<RedSocialMunicipio>();
                for (int i = 0; i < RedesSocialesMunicipio.Count; i++)
                {
                    if (RedesSocialesMunicipio[i].IdRedSocialMunicipio != idRed)
                    {
                        redesAux.Add(RedesSocialesMunicipio[i]);
                    }
                }
                RedesSocialesMunicipio = new List<RedSocialMunicipio>();
                RedesSocialesMunicipio = redesAux;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private void Guardar()
        {
            NavigationManager.NavigateTo("/ContactoMunicipio");
        }
    }
}
