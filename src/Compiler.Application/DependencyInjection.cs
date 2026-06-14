using Compiler.Application.Contracts.Services;
using Compiler.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IProyectoService, ProyectoService>();
        services.AddTransient<IAplicacionService, AplicacionService>();
        services.AddTransient<ICarpetaService, CarpetaService>();
        services.AddTransient<IArchivoExclusionService, ArchivoExclusionService>();
        services.AddTransient<IArchivoAdmitidoService, ArchivoAdmitidoService>();
        services.AddTransient<ITaskRunnerService, TaskRunnerService>();

        return services;
    }
}
