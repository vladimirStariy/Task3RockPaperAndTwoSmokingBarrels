using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace Task3RockPaperAndTwoSmokingBarrels
{
    public static class MoveHasher
    {
        public static string GetHMACByMove(string move)
        {
            Sha3Digest hashAlg = new Sha3Digest(256);

            byte[] _move = Encoding.ASCII.GetBytes(move);

            hashAlg.BlockUpdate(_move, 0, _move.Length);

            byte[] result = new byte[32];
            hashAlg.DoFinal(result, 0);

            string hashString = BitConverter.ToString(result);
            hashString = hashString.Replace("-", "").ToLowerInvariant();
            return hashString;
        }
    }
}
