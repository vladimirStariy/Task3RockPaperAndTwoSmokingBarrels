namespace Task3RockPaperAndTwoSmokingBarrels
{
    public class Game
    {
        private readonly MovesList _movesList;

        public bool isValidated { get; private set; }

        public Game(MovesList movesList)
        {
            _movesList = movesList;
            isValidated = false;
        } 

        public bool ValidateGame()
        {

        }
    }
}
