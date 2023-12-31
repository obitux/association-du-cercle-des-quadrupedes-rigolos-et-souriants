using _01_CQRS_without_event_sourcing.Adapters;
using _01_CQRS_without_event_sourcing.App.Secrétariat.AjouterUnMembre;
using _01_CQRS_without_event_sourcing.App.Secrétariat.ChangerLEmailDunMembre;
using _01_CQRS_without_event_sourcing.App.Secrétariat.ListerTousLesMembres;

namespace _01_CQRS_without_event_sourcing.App;

public static class SecretariatModule
{
    public static IServiceCollection RegisterAppModule(this IServiceCollection services)
    {
        services.AddSingleton<IMembreRepository>(sp => new InMemoryMembreRepository());

        services.AddScoped<IQueryBus>(sp => new InMemoryQueryBus(sp));
        services.AddScoped<ICommandBus>(sp => new CommandBusLogger(new InMemoryCommandBus(sp)));

        services.AddScoped<IQueryHandler<ListerLesMembresQuery, List<MembreReadModel>>>(sp =>
            new ListerLesMembresHandler(sp.GetRequiredService<IMembreRepository>()));

        services.AddScoped<ICommandHandler<AjouterUnMembreCommand>>(sp =>
            new AjouterUnMembreHandler(sp.GetRequiredService<IMembreRepository>()));

        services.AddScoped<ICommandHandler<ChangerLEmailDUnMembreCommand>>(sp =>
            new ChangerLEmailDUnMembreHandler(sp.GetRequiredService<IMembreRepository>()));

        return services;
    }
}