using Task3RockPaperAndTwoSmokingBarrels;

Game game = new Game();
Bot bot = new Bot();

while (!game.isValidated)
{
    string input = Console.ReadLine();

    game.Initialize(input);
    bot.Initialize(game.movesList.Items.Count);
}

while (true)
{
    var currentBotMoveId = bot.GetBotMove(game.movesList.Items);

    Console.WriteLine("Available moves: ");
    game.movesList.PrintMovesList();
    Console.WriteLine("Enter your move: ");
    string input = Console.ReadLine();

    if (input == "0")
    {
        Console.WriteLine("Game over.");
        break;
    }
    if (input == "?")
    {
        Console.WriteLine("Question detected");
        return;
    }
    
    var currentUserId = input;

    game.movesList.CompareInputs(Convert.ToInt32(currentUserId), currentBotMoveId);
}

Console.ReadKey();