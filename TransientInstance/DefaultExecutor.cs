
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using System;
using TransientInstance.Cryptor;

public class DefaultExecutor
{
    public static void Execute(Container container)
    {

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient((provider) => provider.GetRequiredService<ICryptorService>().GetCryptor(container));
        serviceCollection.AddScoped<ICryptorService, CryptorService>();
        serviceCollection.AddSingleton<NewCryptor>();
        serviceCollection.AddSingleton<OldCryptor>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        Console.WriteLine("1. Service Provider with Transient Scope");
        Console.WriteLine();
        GetServiceProviderInstance(serviceProvider);
        Console.WriteLine();

        Console.WriteLine("2. Static Instance");
        Console.WriteLine();
        GetStaticInstance(serviceProvider);
        Console.WriteLine();

        serviceCollection.AddScoped((provider) => provider.GetRequiredService<ICryptorService>().GetCryptor(container));
        serviceProvider = serviceCollection.BuildServiceProvider();
        Console.WriteLine("3. Service Provider with Scoped Scope");
        Console.WriteLine();
        GetServiceProviderInstance(serviceProvider);
        Console.WriteLine();
    }

    static void GetServiceProviderInstance(IServiceProvider serviceProvider)
    {
        var oldObject = serviceProvider.GetRequiredService<Cryptor>();
        var newObject = serviceProvider.GetRequiredService<Cryptor>();
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Is same instance?");
        Console.WriteLine(IsSameInstance(oldObject, newObject));
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
    }

    static void GetStaticInstance(IServiceProvider serviceProvider)
    {
        var oldObject = CryptorWrapper.GetCryptor();
        var newObject = CryptorWrapper.GetCryptor();
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Is same instance?");
        Console.WriteLine(IsSameInstance(oldObject, newObject));
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
    }

    static bool IsSameInstance(object oldObject, object newObject)
    {
        return oldObject.Equals(newObject);
    }
}
