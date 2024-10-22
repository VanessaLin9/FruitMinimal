using FruitMinimal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FruitMinimal.StartUp;

public static class ServiceInit
{
    public static void RegisterService(this WebApplicationBuilder builder)
    {
        builder.Services.TryAddTransient<FruitService>();
    }
}