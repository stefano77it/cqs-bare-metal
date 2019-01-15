using System;

namespace CqsBareMetal.Server
{
    public class Book
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public DateTime DatePublished { get; set; }
        public bool InMyPossession { get; set; }
    }
}