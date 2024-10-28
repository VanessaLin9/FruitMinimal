using FruitMinial.EndPoints.Request;
using FruitMinial.Models;

namespace FruitMinimal.Services;

public class FruitService
{
    public void UpdateFruit(TestRequest request)
    {
        Console.WriteLine($"========>.    Q1:{request.Q1}, Q2:{request.Q2}");
    }

    public int GetFruits(string Q2)
    {
        Console.WriteLine($"========>.    Q2:{Q2}");
        return 1;
        //return int.Parse(Q2);
    }

    public IEnumerable<string> YieldReturnAvailableFruit(Fruit[] Fruits)   
    {
        foreach (var fruit in Fruits)
        {
            if (fruit.Quantity > 0)
            {
                yield return fruit.Name;
            }
        }
    }
}