using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class OfficeUtils
    {
        private const int OfficeNumberMaxLen = 5;

        public static string PadOfficeNumber(string officeNumber)
        {
            return officeNumber.Trim().PadLeft(OfficeNumberMaxLen, '0');
        }
    }
}
