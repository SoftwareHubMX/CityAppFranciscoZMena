using AKSoftware.Localization.MultiLanguages;
using Blazored.LocalStorage;
using CityApp.Client.Logic.TablaCuentasLogic;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Migrations;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OfficeOpenXml;
using System.Net.NetworkInformation;

namespace CityApp.Client.Components.TablaCuentasComponents
{
    public partial class TablaCuentas
    {
        [Inject] private HttpClient Cliente { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] ILanguageContainerService ViewString { get; set; }
        private string archivoIdioma = "";
        [Inject] IJSRuntime js { get; set; }
        IJSObjectReference modulo;

        private Sesion Sesion = new Sesion();

        private List<Rol> Roles = new List<Rol>();
        private List<Cuenta> Cuentas = new List<Cuenta>();
        private List<Cuenta> CuentasSinPaginacion = new List<Cuenta>();
        private FiltroCuentas FiltroCuentas = new FiltroCuentas();

        private bool banderaLoader = false;
        private string alertaDescarga = "";
        private string alerta = "";

        private int idRol = 0;
        private string idRolError = "";

        //Diseño
        private List<int> paginas = new List<int>();
        private int paginaActual = 1;

        protected override async Task OnInitializedAsync()
        {
            Sesion = await LocalStorage.GetItemAsync<Sesion>("sesion");
            if (Sesion != null)
            {
                FiltroCuentas.MaximoElementos = 20;
                FiltroCuentas.Pagina = 1;
                ConsultarRoles();
                ConsultarCuentas();
            }
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firtsRender)
        {
            if (firtsRender)
            {
                modulo = await js.InvokeAsync<IJSObjectReference>("import", "../Js/DescargaArchivos/DescargaArchivos.js");
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
                StateHasChanged();
            }
        }

        private async void ConsultarRoles()
        {
            Response<List<Rol>> response = new Response<List<Rol>>();
            SelectRolesLogic selectRolesLogic = new SelectRolesLogic(Cliente);
            response = await selectRolesLogic.SelectAll();
            if (response.Status.Exito == 1)
            {
                Roles = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            StateHasChanged();
        }

        private async void ConsultarCuentas()
        {
            banderaLoader = false;
            paginas = new List<int>();
            Cuentas = new List<Cuenta>();
            Response<List<Cuenta>> response = new Response<List<Cuenta>>();
            SelectCuentasFiltroCuentasLogic selectCuentasFiltroCuentasLogic = new SelectCuentasFiltroCuentasLogic(Cliente);
            response = await selectCuentasFiltroCuentasLogic.SelectAll(FiltroCuentas);
            if (response.Status.Exito == 1)
            {
                Cuentas = response.Data;
                int paginasExistentes = int.Parse(response.Info.TotalData.ToString());
                for (int i = 1; i <= paginasExistentes; i++)
                {
                    paginas.Add(i);
                }
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaLoader = true;
            StateHasChanged();
        }
        private async void CambiarPaginaActual(int page)
        {
            Cuentas = new List<Cuenta>();
            paginaActual = page;
            FiltroCuentas.Pagina = paginaActual;
            StateHasChanged();
            ConsultarCuentas();
        }

        private void TxtIdRol(ChangeEventArgs args)
        {
            idRol = int.Parse(args.Value.ToString());
            if (idRol != 0)
            {
                idRolError = "";
                FiltroCuentas.IdRol = idRol;
            }
            else
            {
                FiltroCuentas.IdRol = idRol;
            }
            ConsultarCuentas();
            StateHasChanged();
        }

        private void limpiarFiltro()
        {
            idRol = 0;

            Cuentas = new List<Cuenta>();
            FiltroCuentas = new FiltroCuentas();
            FiltroCuentas.Pagina = 1;
            FiltroCuentas.MaximoElementos = 20;
            ConsultarCuentas();
            StateHasChanged();
        }
        private async Task ConsultarCuentassinPaginacion()
        {
            banderaLoader = false;
            var filtro = new FiltroCuentas
            {
                IdRol = FiltroCuentas.IdRol,
                MaximoElementos = 10000,
                Pagina = 1
            };

            CuentasSinPaginacion = new List<Cuenta>();
            var logic = new SelectCuentasFiltroCuentasLogic(Cliente);
            var response = await logic.SelectAll(filtro);
            if (response.Status.Exito == 1)
            {
                CuentasSinPaginacion = response.Data;
            }
            else
            {
                alerta = response.Status.Mensaje;
            }
            banderaLoader = true;
            StateHasChanged();
        }

        private async Task DescargarTodasLasCuentasExcel()
        {
            await ConsultarCuentassinPaginacion();
            await DescargarArchivosExcel(CuentasSinPaginacion);
        }

        private async Task DescargarArchivosExcel(List<Cuenta> cuenta)
        {
            try
            {
                if (cuenta != null && cuenta.Count > 0)
                {
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Cuentas");

                        worksheet.Cells["A1"].Value = "ID";
                        worksheet.Cells["B1"].Value = "Usuario";
                        worksheet.Cells["C1"].Value = "Rol";
                        worksheet.Cells["D1"].Value = "Estatus";
                        worksheet.Cells["E1"].Value = "Nombre";
                        worksheet.Cells["F1"].Value = "Telefono";
                        worksheet.Cells["G1"].Value = "Email";
                        worksheet.Cells["H1"].Value = "Fecha Registro";

                        for (int i = 0; i < cuenta.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1].Value = cuenta[i].IdCuenta;
                            worksheet.Cells[i + 2, 2].Value = cuenta[i].NombreUsuario;
                            worksheet.Cells[i + 2, 3].Value = cuenta[i].Rol.NombreRol;
                            worksheet.Cells[i + 2, 4].Value = cuenta[i].EstatusActivo ? "Activo" : "Inactivo";
                            worksheet.Cells[i + 2, 5].Value = $"{cuenta[i].Usuario.Nombre} {cuenta[i].Usuario.Apellidos}";
                            worksheet.Cells[i + 2, 6].Value = cuenta[i].Usuario.Telefono;
                            worksheet.Cells[i + 2, 7].Value = cuenta[i].Contacto.Correo;
                            worksheet.Cells[i + 2, 8].Value = cuenta[i].FechaRegistro.ToString("dd/MM/yyyy");
                        }
                        await modulo.InvokeVoidAsync("SaveFile", "CityAppChilapa_Cuentas.xlsx", Convert.ToBase64String(package.GetAsByteArray()));
                    }
                    alertaDescarga = "Exito";
                }
                else
                {
                    alertaDescarga = "Ocurrio un error";
                }
            }
            catch (Exception ex)
            {
                alertaDescarga = ex.Message;
            }
            StateHasChanged();
            await Task.Delay(8000);
            alertaDescarga = "";
            StateHasChanged();
        }
    }
}
