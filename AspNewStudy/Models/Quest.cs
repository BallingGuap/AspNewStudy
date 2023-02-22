using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNewStudy.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime Time { get; set; }
        public int MinPlayersCount { get; set; }
        public int MaxPlayersCount { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int Rating { get; set; }
        public string FearScale { get; set; }
        public string HardScale { get; set; }
        public string Logo { get; set; }
        public IEnumerable<string> Photos { get; set; }
    }
}