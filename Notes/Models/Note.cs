using System;

namespace Notes.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
