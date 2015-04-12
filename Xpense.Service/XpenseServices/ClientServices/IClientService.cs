using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpense.Data.DataContext;
using Xpense.Model.Entities;

namespace Xpense.Service.XpenseServices.ClientServices
{
    public interface IClientService : IDataReaderServices<ClientModel>
    {
    }
}
