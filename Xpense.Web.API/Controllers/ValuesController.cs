using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xpense.Model.Entities;
using Xpense.Service.XpenseServices.ClientServices;

namespace Xpense.Web.API.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IClientService _svc;
        public ValuesController(IClientService svc)
        {
            _svc = svc;
        }

        // GET api/values
        public IQueryable<ClientModel> Get()
        {
            return _svc.GetAll();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
