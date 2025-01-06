
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using System;
using TransientInstance.Cryptor;

public class SimpleInjectorExecutor
{

    public static void Execute(IServiceProvider serviceProvider)
    {
        while (true)
        {
            Console.WriteLine("1. Service Provider with Transient Scope");
            Console.WriteLine();
            GetServiceProviderInstance(serviceProvider);
            Console.WriteLine();

            Console.WriteLine("2. Static Instance");
            Console.WriteLine();
            GetStaticInstance(serviceProvider);
            Console.WriteLine();
        }
    }

    static void GetServiceProviderInstance(IServiceProvider serviceProvider)
    {
        var oldObject = serviceProvider.GetService(typeof(Cryptor)) as Cryptor;
        var newObject = serviceProvider.GetService(typeof(Cryptor)) as Cryptor;
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
        return Object.ReferenceEquals(oldObject, newObject);
    }
}
