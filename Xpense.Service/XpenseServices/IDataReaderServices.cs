using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpense.Service.XpenseServices
{
    public interface IDataReaderServices<T>
    {
        IQueryable<T> GetAll();
        T GetById(object id);
    }
}
