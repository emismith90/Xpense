using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpense.Model.Entities
{
    public class RefreshTokenModel
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string ClientId { get; set; }
        public System.DateTime IssuedUtc { get; set; }
        public System.DateTime ExpiresUtc { get; set; }
        public string ProtectedTicket { get; set; }
    }
}
