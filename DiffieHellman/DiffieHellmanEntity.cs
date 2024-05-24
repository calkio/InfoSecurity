using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DiffieHellman
{
    public class DiffieHellmanEntity
    {
        public int NumerUser { get; init; }
        public BigInteger PrivateKey { get; init; }
        public BigInteger PublicKey { get; init; }
        public BigInteger SharedKey {  get; init; }

        public DiffieHellmanEntity(int numerUser, BigInteger privateKey, BigInteger publicKey, BigInteger sharedKey)
        {
            NumerUser = numerUser;
            PrivateKey = privateKey;
            PublicKey = publicKey;
            SharedKey = sharedKey;
        }
    }
}
