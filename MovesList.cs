namespace Task3RockPaperAndTwoSmokingBarrels
{
    public class MovesList
    {
        public List<Move> Items = new List<Move>();
        public int offset;
        public MovesList() { }

        public string GetMoveById(int id)
        {
            return Items.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
        }

        public void PrintMovesList()
        {
            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        public void CompareInputs(int userInput, int botInput)
        {
            var a = (userInput + offset) % Items.Count;
            if (a < botInput)
            {
                Console.WriteLine("User input: " + userInput);
                Console.WriteLine("Bot input: " + botInput);
                Console.WriteLine("Bot wins");
            }
            if (userInput == botInput)
            {
                Console.WriteLine("User input: " + userInput);
                Console.WriteLine("Bot input: " + botInput);
                Console.WriteLine("Draw");
            }
            if (a > botInput)
            {
                Console.WriteLine("User input: " + userInput);
                Console.WriteLine("Bot input: " + botInput);
                Console.WriteLine("You win");
            }
        }

    }
}
