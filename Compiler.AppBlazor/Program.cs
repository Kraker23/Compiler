using BlazorDesktop.Hosting;
using Compiler.AppBlazor.Components;
using Compiler.BL;
using Compiler.EF;
using Compiler.Shared.Interface.IBL;
using Compiler.Shared.Interface.IData;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
//https://github.com/DotNetExtension/BlazorDesktop
var builder = BlazorDesktopHostBuilder.CreateDefault(args);

builder.RootComponents.Add<Routes>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Window.UseTitle("Compiler");
builder.Window.UseIcon("compilador.ico");
builder.Services.AddRadzenComponents();


builder.Services.AddTransient<IManagerJson, ManagerJson>();
//Data
builder.Services.AddTransient<IProyecto_Data, Proyecto_EF>();
builder.Services.AddTransient<IAplicacion_Data, Aplicacion_EF>();
builder.Services.AddTransient<IArchivoExclusion_Data, ArchivoExclusion_EF>();
builder.Services.AddTransient<ICarpeta_Data, Carpeta_EF>();
//BL
builder.Services.AddTransient<IAplicacion_BL, Aplicacion_BL>();
builder.Services.AddTransient<IProyecto_BL, Proyecto_BL>();
builder.Services.AddTransient<IArchivoExclusion_BL, ArchivoExclusion_BL>();
builder.Services.AddTransient<ICarpeta_BL, Carpeta_BL>();


if (builder.HostEnvironment.IsDevelopment())
{
    builder.UseDeveloperTools();
}

await builder.Build().RunAsync();
