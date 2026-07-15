using AKSoftware.Localization.MultiLanguages;
using Append.Blazor.Notifications;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using CityApp.Client;
using CityApp.Client.Services.SoketSignalR;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Globalization;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/")
});

builder.Services.AddSingleton(new SignalRService(
    builder.HostEnvironment.BaseAddress + "notificacioneshub"));

builder.Services.AddNotifications();

builder.Services.AddMudServices();

builder.Services.AddLanguageContainer(
    Assembly.GetExecutingAssembly(),
    CultureInfo.GetCultureInfo("es-MX"));

await builder.Build().RunAsync();
