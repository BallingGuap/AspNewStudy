﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNewStudy.Models
{
    public class IndexViewModel<T>
    {
        public IEnumerable<T> Objects { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}