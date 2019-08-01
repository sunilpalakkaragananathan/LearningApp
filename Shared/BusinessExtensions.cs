using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class BusinessExtensions
    {
        public static string ToMaskedSSN(this string SSN)
        {
            if (SSN.Length == 9)
            {
                return $"XXX-XX-{SSN.Substring(4, 4)}";
            }
            else return string.Empty;
        }
    }
}
