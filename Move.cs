namespace Task3RockPaperAndTwoSmokingBarrels
{
    public class Move
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Move(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
