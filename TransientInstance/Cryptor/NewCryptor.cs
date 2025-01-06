using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransientInstance.Cryptor
{
    internal class NewCryptor : Cryptor
    {
        public NewCryptor(string certificateName) : base(certificateName)
        {
        }
    }
}
