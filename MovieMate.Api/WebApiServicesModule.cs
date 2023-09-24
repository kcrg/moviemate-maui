using Microsoft.Extensions.DependencyInjection;
using MovieMate.Api.Requests;
using Polly.Timeout;
using Polly;
using Refit;
using System.Text.Json;
using Polly.Extensions.Http;
using MovieMate.Api.Models;

namespace MovieMate.Api;

public static class WebApiServicesModule
{
    public static IServiceCollection RegisterRefitApiServices(this IServiceCollection services)
    {
        var options = new JsonSerializerOptions
        {
            TypeInfoResolver = JsonSourceGenerationContext.Default
        };
        RefitSettings refitSettings = new()
        {
            ContentSerializer = new SystemTextJsonContentSerializer(options),
        };

        var retryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<TimeoutRejectedException>()
            .WaitAndRetryAsync(2, _ => TimeSpan.FromMilliseconds(500));

        var timeoutPolicy = Policy
            .TimeoutAsync<HttpResponseMessage>(30);

        services.AddRefitClient<IMyMoviesApi>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://filmy.programdemo.pl"))
            .AddPolicyHandler(retryPolicy)
            .AddPolicyHandler(timeoutPolicy);

        return services;
    }

    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {

        return services;
    }
}