using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNewStudy.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmailD { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}