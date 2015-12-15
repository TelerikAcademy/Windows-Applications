namespace WorkWithJsonDataUWP.Models
{
    using System;

    public class Datum
    {
        public int id { get; set; }
        public string title { get; set; }
        public string mainImageUrl { get; set; }
        public DateTime createdOn { get; set; }
        public string shortDate { get; set; }
        public int likes { get; set; }
        public int visits { get; set; }
        public int comments { get; set; }
        public int flags { get; set; }
        public bool isHidden { get; set; }
        public string titleUrl { get; set; }
        public Collaborator[] collaborators { get; set; }
        public Tag[] tags { get; set; }
    }
}