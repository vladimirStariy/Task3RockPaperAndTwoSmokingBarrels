using Task3RockPaperAndTwoSmokingBarrels;

bool isOver = false;

Game game = new Game();

while (!game.isValidated)
{
    string input = Console.ReadLine();
    if(game.ValidateGame(input))
    {
        break;
    }
}

game.Start();

Console.ReadKey();