using Compiler.Application.Contracts.Data;
using Compiler.Application.Contracts.Execution;
using Compiler.Infrastructure.Persistence.Json;
using Compiler.Infrastructure.Persistence.Repositories;
using Compiler.Infrastructure.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<ICommandRunner, CommandRunner>();
        services.AddSingleton<IJsonDataManager, JsonDataManager>();

        services.AddTransient<IProyectoData, ProyectoData>();
        services.AddTransient<IAplicacionData, AplicacionData>();
        services.AddTransient<ICarpetaData, CarpetaData>();
        services.AddTransient<IArchivoExclusionData, ArchivoExclusionData>();
        services.AddTransient<IArchivoAdmitidoData, ArchivoAdmitidoData>();

        return services;
    }
}
