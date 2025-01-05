namespace TransientInstance.Cryptor;

public interface ICryptorService
{
    Cryptor GetCryptor(IServiceProvider provider);
}
