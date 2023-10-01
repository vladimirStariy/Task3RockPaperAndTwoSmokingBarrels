using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace Task3RockPaperAndTwoSmokingBarrels
{
    public class Bot
    {
        Sha3Digest hashAlg = new Sha3Digest(256);

        private int maxValue = 0;
        
        public Bot() { }

        public void Initialize(int maxValue)
        {
            this.maxValue = maxValue;
        }

        public int GetBotMove(List<Move> moves)
        {
            var moveId = GetBotMoveId(maxValue);
            var HMAC = GetMoveHMAC(moves.Where(x => x.Id == moveId).Select(x => x.Name).FirstOrDefault());
            Console.WriteLine("HMAC: " + HMAC.ToUpper());
            return moveId;
        }

        private int GetBotMoveId(int maxValue)
        {
            Random random = new Random();
            return random.Next(1, maxValue);
        }

        private string GetMoveHMAC(string move)
        {
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
