using Application.Interfaces.Services.ThingsMakerService;
using Application.Services.ThingsMakerService;
using DoManyThings;
using Infraestructure.DBAccess;
using Infraestructure.Repository;
using Interfaces.DBAccess;
using Interfaces.Infraestructure.Database;
using Interfaces.Logic.ThingsMaker;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjections
{
    public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
    {
        //AddScoped //Nova instancia de Employee a cada request
        //AddSingleton //Mesma instancia de Employee durante toda a sessao
        //AddTransient //No mesmo request, sempre q achar Employee ele cria uma nova instancia tipo o New

        //Applications
        services.AddSingleton<IThingsMaker, ThingsMaker>();

        //Services
        services.AddSingleton<IThingsMakerService, ThingsMakerService>();

        //DB
        services.AddSingleton<IExampleDBRepository, ExampleDBRepository>();
        services.AddSingleton<ISQLDataAccess, SQLDataAccess>();

        return services;
    }
}
