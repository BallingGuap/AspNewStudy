using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNewStudy.Models
{
    public class QuestContext
        : DbContext
    {
        public DbSet<Quest> Quests { get; set; }
    }
}