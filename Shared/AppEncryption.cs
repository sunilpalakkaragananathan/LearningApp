using Shared.Interface;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Shared
{
    public class AppEncryption : IAppEncryption
    {
        private ICryptoTransform m_Decryptor = null;
        private string m_DecryptionKeyID;
        private ICryptoTransform m_Encryptor = null;
        private string m_EncryptionKeyID;
        private readonly IKeyManager keyManager;

        public AppEncryption(IKeyManager keyManager)
        {
            this.keyManager = keyManager;
        }
        public string DecryptString(string KeyId, byte[] cipherText)
        {
            if (cipherText == null)
                return null;
            else
                return Encoding.UTF8.GetString(AppDecrypt(KeyId, cipherText));
        }

        private byte[] AppDecrypt(string keyID, byte[] cipherText)
        {
            // if the keyID is null then the data is not encrypted
            if (keyID == null)
                return cipherText;

            if (m_Decryptor == null || keyID != m_DecryptionKeyID)
            {
                if (m_Decryptor != null)
                    m_Decryptor.Dispose();

                using (SymmetricAlgorithm alg = keyManager.CreateAlgorithmByKeyID(keyID))
                {
                    m_DecryptionKeyID = keyID;
                    m_Decryptor = alg.CreateDecryptor();
                }
            }
            
            return m_Decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
        }

    }
}
