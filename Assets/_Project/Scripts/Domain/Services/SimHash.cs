using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace _Project.Scripts.Domain.Services
{
    public static class SimHash
    {
        private const int HashBits = 64;
        
        public static ulong Compute(IEnumerable<int> sequence)
        {
            var vector = new int[HashBits];

            foreach (var value in sequence)
            {
                ulong hash = Hash64(value.ToString());
                for (int i = 0; i < HashBits; i++)
                {
                    int bit = ((hash >> i) & 1) == 1 ? 1 : -1;
                    vector[i] += bit * value; 
                }
            }

            ulong fingerprint = 0;
            for (int i = 0; i < HashBits; i++)
            {
                if (vector[i] > 0)
                    fingerprint |= 1UL << i;
            }

            return fingerprint;
        }

        public static int HammingDistance(ulong hash1, ulong hash2)
        {
            ulong x = hash1 ^ hash2;
            int count = 0;
            while (x != 0)
            {
                count++;
                x &= (x - 1);
            }
            return count;
        }
        
        private static ulong Hash64(string input)
        {
            using var md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToUInt64(bytes, 0);
        }
    }
}