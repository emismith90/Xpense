using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xpense.Data.DataContext;

namespace Xpense.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private XpenseEntities dataContext;
        public XpenseEntities Get()
        {
            return dataContext ?? (dataContext = new XpenseEntities());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
