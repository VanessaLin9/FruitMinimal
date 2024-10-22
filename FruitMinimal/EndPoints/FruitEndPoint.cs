using FruitMinimal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FruitMinimal.EndPoints;

public static class FruitEndPoint
{
    public static IEndpointRouteBuilder MapFruitApi(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/Fruit");

        app.MapGet("/", GetFruits);
        app.MapPut("/", UpdateFruit);

        return app;
    }

    private static Ok<string> UpdateFruit(FruitService fruitService)
    {
        fruitService.UpdateFruit();
        return TypedResults.Ok("Updated Apple!");
    }

    private static Ok<string> GetFruits(FruitService fruitService)
    {
        fruitService.GetFruits();
        return TypedResults.Ok("apple!");
    }
}