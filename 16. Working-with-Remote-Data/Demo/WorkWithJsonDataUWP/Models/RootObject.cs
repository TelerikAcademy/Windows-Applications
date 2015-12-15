namespace WorkWithJsonDataUWP.Models
{
    public class RootObject
    {
        public bool success { get; set; }
        public object errorMessage { get; set; }
        public Datum[] data { get; set; }
    }
}