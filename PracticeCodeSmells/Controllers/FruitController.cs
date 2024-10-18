using Microsoft.AspNetCore.Mvc;

namespace PracticeCodeSmells.Controllers;

public class FruitController : Controller
{
    public FruitResponse Index(string fruitName,
        int quantity,
        string customerName,
        string cardNumber,
        string paymentType,
        string appleSt,
        string expiryDate)
    {
        FruitService service = new FruitService();

        int aaa = service.IsFruitAvailable(fruitName, quantity);

        if (aaa != -1)
        {
            return new FruitResponse()
            {
                ErrorMessage = "Not enough apples in stock."
            };
        }

        int res = service.ValidateCreditCard(cardNumber, expiryDate);
        if (res == -1)
        {
            return new FruitResponse()
            {
                ErrorMessage = "Invalid credit card."
            };
        }

        service.ProcessOrder(fruitName, quantity, customerName, appleSt, paymentType, cardNumber, expiryDate);

        service.ShipOrder(customerName, appleSt, fruitName, quantity);

        return new FruitResponse()
        {
        };
    }
}

public class FruitResponse
{
    public string ErrorMessage { get; set; }
}

class FruitService
{
    public void ProcessOrder(string fruitName,
        int quantity,
        string customerName,
        string address,
        string paymentType,
        string cardNumber,
        string expiryDate)
    {
        if (fruitName == "Apple" && quantity > 0)
        {
            if (paymentType == "CreditCard")
            {
                if (cardNumber.Length == 16 && expiryDate != null)
                {
                    Console.WriteLine(
                        $"Order processed for {quantity} {fruitName}(s) to {customerName}, {address}. Payment method: {paymentType}.");
                }
            }
            else if (paymentType == "PayPal")
            {
                Console.WriteLine($"PayPal payment processed for {customerName}.");
            }
        }
        else if (fruitName == "Banana" && quantity > 0)
        {
            if (paymentType == "CreditCard")
            {
                if (cardNumber.Length == 16 && expiryDate != null)
                {
                    Console.WriteLine(
                        $"Order processed for {quantity} {fruitName}(s) to {customerName}, {address}. Payment method: {paymentType}.");
                }
            }
        }
    }

    public int IsFruitAvailable(string fruitName, int quantity)
    {
        if (fruitName == "Apple" && quantity <= 100)
        {
            return 1;
        }
        else if (fruitName == "Banana" && quantity <= 200)
        {
            return 1;
        }

        return -1;
    }

    public int ValidateCreditCard(string cardNumber, string expiryDate)
    {
        if (cardNumber.Length == 16 && !string.IsNullOrEmpty(expiryDate))
        {
            return 1;
        }

        return -1;
    }

    public void ShipOrder(string customerName, string address, string fruitName, int quantity)
    {
        Console.WriteLine($"Shipping {quantity} {fruitName}(s) to {customerName}, {address}.");
    }
}