namespace Task3RockPaperAndTwoSmokingBarrels
{
    public class Game
    {
        public MovesList movesList = new MovesList();

        public bool isValidated { get; private set; }
        private int offset;

        public Game()
        {
            isValidated = false;
            offset = 0;
        }

        private bool ValidateInput(List<string> values)
        {
            if (values.Count == 0)
            {
                Console.WriteLine("No options.");
                return false;
            }
            if (values.Count < 3)
            {
                Console.WriteLine("The number of options is less than 3.");
                return false;
            }
            if (values.Count % 2 == 0)
            {
                Console.WriteLine("The number of options is honest.");
                return false;
            }
            // допилить проверку на повторы

            return true;
        }

        private void MapMovesList(List<string> values)
        {
            for(int i = 0; i < values.Count; i++)
            {
                movesList.Items.Add(new Move(i+1, values[i]));
            }
        }

        public void Initialize(string input)
        {
            List<string> values = input.Split(' ').ToList();
            values.RemoveAll(val => val == "");
            if (ValidateInput(values))
            {
                MapMovesList(values);
                offset = movesList.Items.Count / 2;
                movesList.offset = offset;
                isValidated = true;
            }
        }
    }
}
