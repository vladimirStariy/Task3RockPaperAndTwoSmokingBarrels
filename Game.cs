namespace Task3RockPaperAndTwoSmokingBarrels
{
    public class Game
    {
        private readonly MovesList _movesList = new MovesList();
        private HelpTable helpTable;
        public bool isValidated { get; private set; }
        private Bot bot;

        public bool isOver = false;

        public Game()
        {
            isValidated = false;
        } 

        public bool ValidateGame(string input)
        {
            if (_movesList.TryInitializeMovesList(input))
            {
                isValidated = true;
                helpTable = new HelpTable(_movesList);
                return true;
            }
            else return false;
        }

        public void Start()
        {
            if(!isValidated)
            {
                Console.WriteLine("The game is not validated");
                return;
            }

            bot = new Bot(_movesList.Items.Length);
            Console.Clear();
            var botMove = bot.GetBotMove(_movesList);

            
            var userMove = MakeMove();

            if(userMove < 0)
            {

            }

            DetectWinner(userMove, botMove);
        }

        private void PrintAvailableMoves()
        {
            Console.WriteLine("Available moves: ");
            _movesList.PrintMovesList();
        }

        public int MakeMove()
        {
            bool userIsMakeMove = false;
            string userInput = "";

            while (!userIsMakeMove)
            {
                PrintAvailableMoves();
                Console.Write("Enter your move: ");
                userInput = Console.ReadLine();

                if (_movesList.ValidateMoveInput(userInput))
                {
                    userIsMakeMove = true;
                    if (userInput == "0")
                    {
                        Console.WriteLine("Game over.");
                        userIsMakeMove = false;
                        return -1;
                    }
                    if (userInput == "?")
                    {
                        userIsMakeMove = false;
                        helpTable.Print();
                    }
                    if(userIsMakeMove)    
                        return Convert.ToInt32(userInput);
                }
                else
                {
                    Console.WriteLine("Invalid move.");
                }
                userIsMakeMove = false;
            }
            return 0;
        }

        public void DetectWinner(int userInput, int botInput)
        {
            Console.WriteLine("Your move: " + _movesList.GetMoveById(userInput));
            Console.WriteLine("Bot move: " + _movesList.GetMoveById(botInput));

            if (userInput == botInput)
            {
                Console.WriteLine("Draw");
                Console.WriteLine("HMAC" + MoveHasher.GetHMACByMove(_movesList.GetMoveById(userInput)).ToUpper());
                return;
            }

            var max = Math.Max(userInput, botInput);

            if (userInput < botInput)
            {
                var a_dist = max - userInput;

                if (a_dist <= _movesList.offset)
                {
                    Console.WriteLine("You win!");
                }
                else
                {
                    Console.WriteLine("Bot win.");
                }
            }

            if (userInput > botInput)
            {
                var a_dist = _movesList.Items.Count() - max + botInput;

                if (a_dist <= _movesList.offset)
                {
                    Console.WriteLine("You win!");
                }
                else
                {
                    Console.WriteLine("Bot win.");
                }
            }

            Console.WriteLine("HMAC" + MoveHasher.GetHMACByMove(_movesList.GetMoveById(userInput)).ToUpper());
        }

        public void GameOver()
        {
            
        }
    }
}
