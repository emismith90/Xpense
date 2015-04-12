using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpense.Data.Infrastructure
{
    public class GenericRepository<T> : RepositoryBase<T> where T : class
    {
        public GenericRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
