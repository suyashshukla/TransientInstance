using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace TransientInstance.Cryptor;

public class CryptorService : ICryptorService
{
    public Cryptor GetCryptor(Container container)
    {
        return container.GetInstance<NewCryptor>();
    }

    public Cryptor GetCryptor(IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<NewCryptor>();
    }
}
