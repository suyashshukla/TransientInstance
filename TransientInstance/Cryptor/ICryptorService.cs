
using SimpleInjector;

namespace TransientInstance.Cryptor;

public interface ICryptorService
{
    Cryptor GetCryptor(Container container);

    Cryptor GetCryptor(IServiceProvider serviceProvider);
}
