using Microsoft.Extensions.DependencyInjection;

namespace TransientInstance.Cryptor;

public class CryptorService : ICryptorService
{
    public Cryptor GetCryptor(IServiceProvider provider)
    {
        var randomNumber = new Random().Next();

        return provider.GetRequiredService<NewCryptor>();
    }
}
