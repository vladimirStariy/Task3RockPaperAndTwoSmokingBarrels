using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System.Security.Cryptography;
using System.Text;

namespace Task3RockPaperAndTwoSmokingBarrels
{
    public static class MoveHasher
    {
        public static HMAC GetHMACByMove(string move)
        {
            Sha3Digest hashAlg = new Sha3Digest(256);

            var HMac = new HMac(hashAlg);

            var random = RandomNumberGenerator.Create();
            byte[] _key = new byte[32];
            random.GetNonZeroBytes(_key);
            var keyResult = BitConverter.ToString(_key);
            keyResult = keyResult.Replace("-", "").ToLowerInvariant();

            byte[] _move = Encoding.ASCII.GetBytes(move);

            HMac.Init(new KeyParameter(_key));
            HMac.BlockUpdate(_move, 0, _move.Length);          
           
            byte[] result = new byte[32];
            HMac.DoFinal(result, 0);

            string hashString = BitConverter.ToString(result);
            hashString = hashString.Replace("-", "").ToLowerInvariant();

            return new HMAC(hashString, keyResult);
        }
    }
}
