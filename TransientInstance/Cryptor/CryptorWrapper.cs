using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransientInstance.Cryptor
{
    internal static class CryptorWrapper
    {
        private static Cryptor _cryptor;

        public static Cryptor GetCryptor()
        {
            if (_cryptor == null)
            {
                _cryptor = new NewCryptor();
            }

            return _cryptor;
        }
    }
}
