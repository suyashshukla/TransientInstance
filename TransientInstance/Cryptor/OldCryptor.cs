﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransientInstance.Cryptor
{
    internal class OldCryptor : Cryptor
    {
        public OldCryptor(string certificateName) : base(certificateName)
        {
        }
    }
}
