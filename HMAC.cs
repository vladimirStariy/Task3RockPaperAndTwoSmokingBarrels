namespace Task3RockPaperAndTwoSmokingBarrels
{
    public class HMAC
    {
        public string message { get; set; }
        public string key { get; set; }
        public HMAC(string message, string key)
        {
            this.message = message;
            this.key = key;
        }
    }
}
