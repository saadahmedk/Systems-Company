using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Systems_Company
{
    public class CustomGuidGenerator: IGuidGeneratorService
    {
        private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();
        private const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public string GenerateGuid()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString("X8");

            var random1 = GenerateRandomHexString(4);
            var version = "4000".Substring(0, 4);
            var random2 = GenerateRandomHexString(4);
            var node = GenerateRandomHexString(12);

            return $"{timestamp}-{random1}-{version}-{random2}-{node}";
        }

    
        private string GenerateRandomHexString(int length)
        {
            var bytes = new byte[length / 2];
            _rng.GetBytes(bytes);
            return BitConverter.ToString(bytes).Replace("-", "");
        }

      
    }
}
