    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Modules;

namespace AspNewStudy.Models
{
    public class NinjectRegistrations
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<AccountRepository>();
        }
    }
}