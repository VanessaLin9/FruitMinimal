using FruitMinial.EndPoints.Request;
using FruitMinial.Models;
using FruitMinimal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace FruitMinial.EndPoints;

public static class FruitEndPoint
{
    private static readonly Fruit[] Fruits =
    [
        new() { Name = "Apple", Color = "Red", Size = "Medium", Quantity = 10 },
        new() { Name = "Banana", Color = "Yellow", Size = "Medium", Quantity = 20 },
        new() { Name = "Cherry", Color = "Red", Size = "Small", Quantity = 0 },
    ];


    public static IEndpointRouteBuilder MapFruitApi(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/fruit");

        api.MapGet("/", GetFruits);
        api.MapPut("/", UpdateFruit);
        api.MapGet("/remove", GetRemoveResult);
        api.MapGet("/available", GetIteratorFruit);

        return app;
    }

    private static IEnumerable<int> GetRemoveResult(HttpContext context, int id)
    {
        List<int> numbers = [1, 2, 3];
        var enumerable = numbers.Select(number => number * 10);
        numbers.Remove(id);
        return enumerable;
    }


    private static void GetIteratorFruit(FruitService fruitService)
    {
        foreach (var name in fruitService.YieldReturnAvailableFruit(Fruits))
        { 
            Console.WriteLine($"=======> name: {name}");
        }
    }


    private static Ok<string> UpdateFruit(FruitService fruitService, TestRequest request)
    {
        //fruitService.UpdateFruit(request);
        Console.WriteLine($"=======> request: {request.Q1}, {request.Q2}");
        return TypedResults.Ok($"Updated Apple! {request.Q1}, {request.Q2}");
    }

    private static Ok<string> GetFruits(int Q1, int Q2)
    {
        return TypedResults.Ok($"Get! {Q1}, {Q2}");
    }
}