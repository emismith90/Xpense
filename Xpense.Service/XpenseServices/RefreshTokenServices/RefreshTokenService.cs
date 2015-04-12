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
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRepository<RefreshToken> _rtknRepo;
        public RefreshTokenService(IRepository<RefreshToken> rtknRepo)
        {
            _rtknRepo = rtknRepo;
        }

        public IQueryable<RefreshTokenModel> GetAll()
        {
            return _rtknRepo.TableNoTracking.Select(p => new RefreshTokenModel
            {
                Id = p.Id,
                Subject = p.Subject,
                ClientId = p.ClientId,
                IssuedUtc = p.IssuedUtc,
                ExpiresUtc = p.ExpiresUtc,
                ProtectedTicket = p.ProtectedTicket
            });
        }

        public RefreshTokenModel GetById(object id)
        {
            var p = _rtknRepo.Get(id);
            return new RefreshTokenModel
            {
                Id = p.Id,
                Subject = p.Subject,
                ClientId = p.ClientId,
                IssuedUtc = p.IssuedUtc,
                ExpiresUtc = p.ExpiresUtc,
                ProtectedTicket = p.ProtectedTicket
            };
        }

        public async Task AddAsync(RefreshTokenModel entity)
        {
            await _rtknRepo.AddAsync(new RefreshToken
            {
                Id = entity.Id,
                Subject = entity.Subject,
                ClientId = entity.ClientId,
                IssuedUtc = entity.IssuedUtc,
                ExpiresUtc = entity.ExpiresUtc,
                ProtectedTicket = entity.ProtectedTicket
            });
        }

        public async Task UpdateAsync(RefreshTokenModel entity)
        {
            await _rtknRepo.UpdateAsync(new RefreshToken
            {
                Id = entity.Id,
                Subject = entity.Subject,
                ClientId = entity.ClientId,
                IssuedUtc = entity.IssuedUtc,
                ExpiresUtc = entity.ExpiresUtc,
                ProtectedTicket = entity.ProtectedTicket
            }, entity.Id);
        }

        public async Task DeleteAsync(RefreshTokenModel entity)
        {
            await _rtknRepo.DeleteAsync(new RefreshToken
            {
                Id = entity.Id,
                Subject = entity.Subject,
                ClientId = entity.ClientId,
                IssuedUtc = entity.IssuedUtc,
                ExpiresUtc = entity.ExpiresUtc,
                ProtectedTicket = entity.ProtectedTicket
            });
        }


        public async Task DeleteAsync(object id)
        {
            if (id != null)
            {
                var item = await _rtknRepo.FindAsync(p => p.Id == id.ToString());
                if (item != null)
                    await _rtknRepo.DeleteAsync(item);
            }
        }
    }
}
