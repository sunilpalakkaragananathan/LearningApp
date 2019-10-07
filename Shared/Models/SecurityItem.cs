using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class SecurityResource
    {
        private const string DefaultIV = "AAAAAAAAAAAAAAAAAAAAAA==";  // default is 128 bits of all zeros
        private const string DefaultAlgorithm = "Rijndael";

        public string Type { get; set; }
        public string ID { get; set; }
        public string Hash { get; set; }
        public string Value { get; set; }

        public string IV
        {
            get { return DefaultIV; }
        }

        public string Algorithm
        {
            get { return DefaultAlgorithm; }
        }
    }

    public class SecurityResources : List<SecurityResource>
    {

    }

    public class SecurityConfig
    {
        public SecurityResources SecurityResources { get; set; }
    }
}
