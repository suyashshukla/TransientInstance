﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransientInstance.Cryptor
{
    public class Cryptor
    {
        private string certificateName;

        public Cryptor(string certificateName)
        {
            certificateName = "DefaultCertificate";
        }
    }
}
