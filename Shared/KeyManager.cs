using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Shared.Models;

using Microsoft.Extensions.Options;

namespace Shared
{
    public interface IKeyManager
    {
        SymmetricAlgorithm CreateAlgorithmByKeyID(string keyID);
    }
    public class KeyManager : IKeyManager
    {

        private const int KeyIDLen = 4;
        private readonly byte[] m_KeyComponent = new byte[]{0x5a, 0xdf, 0x9f, 0x98, 0x7d, 0x1f, 0x8d, 0xb1, 0x8c, 0xb0, 0x89, 0x25, 0x86, 0x1d, 0xdf, 0xdf,
                                          0xd7, 0x9d, 0xab, 0x01, 0x83, 0xa4, 0xa2, 0x9f, 0xb6, 0x91, 0x85, 0xd1, 0x15, 0x79, 0x6c, 0x78};
        private readonly byte[] m_KeyIDBuf = new byte[KeyIDLen];
        private readonly IOptions<SecurityConfig> securityConfig;

        public KeyManager(IOptions<SecurityConfig> securityConfig)
        {
            this.securityConfig = securityConfig;
        }

        public SymmetricAlgorithm CreateAlgorithmByKeyID(string keyID)
        {
            var securityResource = securityConfig.Value.SecurityResources.SingleOrDefault(s => s.ID == keyID);
            return CreateAlgorithm(securityResource);
        }

        private SymmetricAlgorithm CreateAlgorithm(SecurityResource securityResource)
        {
            SymmetricAlgorithm alg = SymmetricAlgorithm.Create(securityResource.Algorithm);

            try
            {
                alg.Key = GetKeyBytes(securityResource);
                alg.IV = Convert.FromBase64String(securityResource.IV);
                return alg;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Key {0} is invalid.", securityResource.ID), ex);
            }
        }

        private byte[] GetKeyBytes(SecurityResource securityResource)
        {
            byte[] key = Convert.FromBase64String(securityResource.Value);

            for (int i = 0; i < key.Length; i++)
                key[i] ^= m_KeyComponent[i % m_KeyComponent.Length];

            using (HashAlgorithm hAlg = SHA256.Create())
            {
                hAlg.TransformFinalBlock(key, 0, key.Length);
                if (Convert.ToBase64String(hAlg.Hash) != securityResource.Hash)
                    throw new Exception(String.Format("The hash for key {0} is invalid", securityResource.ID));
            }

            return key;
        }
        
    }
}
