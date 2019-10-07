using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interface
{
    public interface IAppEncryption
    {
        string DecryptString(string KeyId, byte[] cipherText); // using byte[] since binary type is not available in core (no system.data.linq)
    }
}
