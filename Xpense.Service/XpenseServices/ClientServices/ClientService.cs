using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpense.Data.DataContext;
using Xpense.Data.Infrastructure;
using Xpense.Model.Entities;

namespace Xpense.Service.XpenseServices.ClientServices
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepo;
        public ClientService(IRepository<Client> clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public IQueryable<ClientModel> GetAll()
        {
            return _clientRepo.TableNoTracking.Select(p => new ClientModel
            {
                Id = p.Id,
                Name = p.Name,
                RefreshTokenLifeTime = p.RefreshTokenLifeTime,
                Secret = p.Secret,
                Active = p.Active,
                AllowedOrigin = p.AllowedOrigin,
                ApplicationType = p.ApplicationType
            });
        }

        public ClientModel GetById(object id)
        {
            var p = _clientRepo.Get(id);
            return new ClientModel
            {
                Id = p.Id,
                Name = p.Name,
                RefreshTokenLifeTime = p.RefreshTokenLifeTime,
                Secret = p.Secret,
                Active = p.Active,
                AllowedOrigin = p.AllowedOrigin,
                ApplicationType = p.ApplicationType
            };
        }

    }
}
