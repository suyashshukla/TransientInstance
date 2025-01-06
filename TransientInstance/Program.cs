
using Microsoft.Extensions.DependencyInjection;
using TransientInstance.Cryptor;
using System.Collections.Generic;
using System.Linq;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.ComponentModel;

var container = new SimpleInjector.Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
container.Options.EnableAutoVerification = false;
container.Options.SuppressLifestyleMismatchVerification = true;
container.Options.ResolveUnregisteredConcreteTypes = true;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSimpleInjector(container, options =>
{
    options.CrossWire<IServiceScopeFactory>();
    serviceCollection.AddTransient<Cryptor>((provider) => container.GetInstance<ICryptorService>().GetCryptor(container));
    container.Register<ICryptorService, CryptorService>(Lifestyle.Scoped);
    serviceCollection.AddSingleton((provider) => new NewCryptor("New Certificate"));
    serviceCollection.AddSingleton((provider) => new OldCryptor("Old Certificate"));
});
var serviceProvider = serviceCollection.BuildServiceProvider();
serviceProvider.UseSimpleInjector(container);
using (var scope = AsyncScopedLifestyle.BeginScope(container))
    SimpleInjectorExecutor.Execute(serviceProvider);
DefaultExecutor.Execute(container);
