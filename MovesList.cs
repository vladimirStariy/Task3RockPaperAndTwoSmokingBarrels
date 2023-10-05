using Org.BouncyCastle.Math.EC.Rfc7748;
using System.Linq;

namespace Task3RockPaperAndTwoSmokingBarrels
{
    public class MovesList
    {
        public Move[] Items { get; private set; }

        public int offset { get; set; }

        public bool TryInitializeMovesList(string[] input)
        {
            if (ValidateInput(input))
            {
                Items = new Move[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    Move move = new Move(i + 1, input[i]);
                    Items[i] = move;
                }
                offset = Items.Length / 2;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetMoveById(int id)
        {
            return Items.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
        }

        public void PrintMovesList()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Console.WriteLine($"{Items[i].Id} - {Items[i].Name}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        private bool ValidateInput(string[] items)
        {
            if (items.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("No options.");
                Environment.Exit(0);
            }
            if (items.Length < 3)
            {
                Console.Clear();
                Console.WriteLine("The number of options is less than 3.");
                Environment.Exit(0);
            }
            if (items.Length % 2 == 0)
            {
                Console.Clear();
                Console.WriteLine("The number of options is honest.");
                Environment.Exit(0);
            }
            if(items.Length != items.Distinct().Count())
            {
                Console.Clear();
                Console.WriteLine("Duplicate values.");
                Environment.Exit(0);
            }

            return true;
        }

        public bool ValidateMoveInput(string input)
        {
            if(input != null)
            {
                var _input = input.Trim(' ');
                if(_input == "0" || _input == "?") return true;
                int userInput;
                try
                {
                    userInput = Convert.ToInt32(_input);
                }
                catch
                {
                    return false;
                }  
                for(int i = 0; i < Items.Length; i++)
                {
                    if (Items[i].Id == userInput)
                    {
                        return true;
                    }
                }
                return false;
            }
            else            
                return false;
        }
    }
}
