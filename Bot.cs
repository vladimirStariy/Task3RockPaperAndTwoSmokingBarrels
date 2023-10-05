using Org.BouncyCastle.Crypto.Digests;
using System.Text;

namespace Task3RockPaperAndTwoSmokingBarrels
{
    public class Bot
    {
        private int maxMoveId = 0;
        public HMAC hmac;

        public Bot(int maxMoveId) { this.maxMoveId = maxMoveId; }

        public int GetBotMove(MovesList moves)
        {
            var moveId = GetBotMoveId(maxMoveId);
            hmac = MoveHasher.GetHMACByMove(moves.Items.Where(x => x.Id == moveId).Select(x => x.Name).FirstOrDefault());
            Console.WriteLine("HMAC: " + hmac.message.ToUpper());
            return moveId;
        }

        private int GetBotMoveId(int maxValue)
        {
            Random random = new Random();
            return random.Next(1, maxValue);
        }
    }
}
