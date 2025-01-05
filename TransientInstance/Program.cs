
using Microsoft.Extensions.DependencyInjection;
using TransientInstance.Cryptor;

var serviceCollection = new ServiceCollection();


serviceCollection.AddTransient((provider) => provider.GetRequiredService<ICryptorService>().GetCryptor(provider));
serviceCollection.AddScoped<ICryptorService, CryptorService>();
serviceCollection.AddTransient<NewCryptor>();
serviceCollection.AddTransient<OldCryptor>();

var serviceProvider = serviceCollection.BuildServiceProvider();

Console.WriteLine("1. Service Provider with Transient Scope");
Console.WriteLine();
GetServiceProviderInstance(serviceProvider);
Console.WriteLine();

Console.WriteLine("2. Static Instance");
Console.WriteLine();
GetStaticInstance(serviceProvider);
Console.WriteLine();

serviceCollection.AddScoped((provider) => provider.GetRequiredService<ICryptorService>().GetCryptor(provider));
serviceProvider = serviceCollection.BuildServiceProvider();
Console.WriteLine("3. Service Provider with Scoped Scope");
Console.WriteLine();
GetServiceProviderInstance(serviceProvider);
Console.WriteLine();

static void GetServiceProviderInstance(IServiceProvider serviceProvider)
{
    var oldObject = serviceProvider.GetRequiredService<Cryptor>();
    var newObject = serviceProvider.GetRequiredService<Cryptor>();
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("Is same instance?");
    Console.WriteLine(Object.ReferenceEquals(oldObject, newObject));
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
}

static void GetStaticInstance(IServiceProvider serviceProvider)
{
    var oldObject = CryptorWrapper.GetCryptor();
    var newObject = CryptorWrapper.GetCryptor();
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("Is same instance?");
    Console.WriteLine(newObject.Equals(oldObject));
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
}
