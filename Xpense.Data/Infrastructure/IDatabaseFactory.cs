using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xpense.Data.DataContext;

namespace Xpense.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        XpenseEntities Get();
    }
}
