using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Products.Application;

namespace HashService
{
    public class SecurityService: ISecurityService
    {
        private readonly IConfiguration _configuration;      
        public SecurityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateHMACSHA512Hash(string input)
        {
            var testeKey = _configuration.GetSection("SecretKey:HashKey");
            var teste = TransformStringIntoByteArray("MEUPAUDEOCULOS");
            using (HMACSHA512 hmac = new HMACSHA512(teste))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = hmac.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool VerifyHMACSHA512Hash(string input, string hash)
        {
            string hashOfInput = CreateHMACSHA512Hash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }
        private byte[] TransformStringIntoByteArray(string key) {
            // Convert string to byte array using UTF-8 encoding
            byte[] byteArray = Encoding.UTF8.GetBytes(key);
            
            return byteArray;
        }        
    }
}
