using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNewStudy.Models
{
    public class IndexListViewModel<T>
    {
        public IEnumerable<T> Objects { get; set; }
        public Hashtable Selects { get; set; }
    }
}