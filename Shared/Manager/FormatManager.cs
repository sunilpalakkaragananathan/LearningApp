using Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Manager
{
    public class FormatManager : IFormatManager
    {
        IAppEncryption appEncryption;
        public FormatManager(IAppEncryption appEncryption)
        {
            this.appEncryption = appEncryption;
        }
        public string Decrypt(string decryptString)
        {
            //byte[] ciphertext = HexStringToBytes("FE1C77C090A8E837B9A377260D2E0AE5").ToArray();
            byte[] ciphertext = HexStringToBytes(decryptString).ToArray();
            return appEncryption.DecryptString("DB01", ciphertext);
        }
        private static IEnumerable<byte> HexStringToBytes(string hexString)
        {
            if (hexString.Length % 2 != 0)
                throw new Exception();

            for (int i = 0; i < hexString.Length; i += 2)
            {
                yield return Convert.ToByte(hexString.Substring(i, 2), 16);
            }
        }
    }
}
