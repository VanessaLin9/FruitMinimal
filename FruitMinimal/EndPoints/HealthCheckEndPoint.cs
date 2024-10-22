using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FruitMinimal.EndPoints;

public static class HealthCheckEndPoint
{
    public static IEndpointRouteBuilder MapHealthCheckApi(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("");

        api.MapGet("/healthz", () => TypedResults.Ok("Healthy"));

        return app;
    }
}