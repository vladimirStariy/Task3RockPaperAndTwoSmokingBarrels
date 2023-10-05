namespace Task3RockPaperAndTwoSmokingBarrels
{
    public class MovesList
    {
        public Move[] Items { get; private set; }

        private int offset { get; set; }

        public bool TryCreateMovesList(string input)
        {
            var _items = input.Split(' ').ToArray().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (ValidateInput(_items))
            {
                Items = new Move[_items.Length];
                for (int i = 0; i < _items.Length; i++)
                {
                    Items[i].Id = i + 1;
                    Items[i].Name = _items[i];
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
                Console.WriteLine($"{Items[i]} - {Items[i].Name}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        public void CompareInputs(int userInput, int botInput)
        {
            Console.WriteLine("User input: " + userInput);
            Console.WriteLine("Bot input: " + botInput);

            if (userInput == botInput)
            {
                Console.WriteLine("Draw");
                return;
            }

            var max = Math.Max(userInput, botInput);
            
            if (userInput < botInput)
            {
                var a_dist = max - userInput;
                
                if (a_dist <= offset)
                {
                    Console.WriteLine("User wins");
                } 
                else
                {
                    Console.WriteLine("Bot wins");
                }
            }
            
            if (userInput > botInput)
            {
                var a_dist = Items.Count() - max + botInput;

                if(a_dist <= offset)
                {
                    Console.WriteLine("User wins");
                }
                else
                {
                    Console.WriteLine("Bot wins");
                }

            }
        }

        private bool ValidateInput(string[] items)
        {
            if (items.Length == 0)
            {
                Console.WriteLine("No options.");
                return false;
            }
            if (items.Length < 3)
            {
                Console.WriteLine("The number of options is less than 3.");
                return false;
            }
            if (items.Length % 2 == 0)
            {
                Console.WriteLine("The number of options is honest.");
                return false;
            }
            // допилить проверку на повторы

            return true;
        }
    }
}
