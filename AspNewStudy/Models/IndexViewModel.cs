using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNewStudy.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Account> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}