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
        new Fruit { Name = "Apple", Color = "Red", Size = "Medium", Quantity = 10 },
        new Fruit { Name = "Banana", Color = "Yellow", Size = "Medium", Quantity = 20 },
        new Fruit { Name = "Cherry", Color = "Red", Size = "Small", Quantity = 0 },
    ];


    private static List<int> _testNumbers = [1, 2, 3];

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


    private static void GetIteratorFruit(HttpContext context)
    {
        foreach (var name in FruitService.IteratorAvailableFruit(Fruits))
        { 
            Console.WriteLine($"=======> name: {name}");
            context.Response.WriteAsync(name + "\n");
            context.Response.Body.Flush();
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