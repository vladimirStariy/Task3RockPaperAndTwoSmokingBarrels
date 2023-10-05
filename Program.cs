using Task3RockPaperAndTwoSmokingBarrels;

Console.Clear();

string[] values = Environment.GetCommandLineArgs();

bool isOver = false;

Game game = new Game();

while (!game.isValidated)
{
    if (game.ValidateGame(values))
    {
        break;
    }
}

game.Start();

Console.ReadKey();