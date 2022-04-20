using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class PlayerController : ApiController
    {
        // GET: api/Player
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Player/5
        public object Get(string userName, string senha)
        {
            
            return "value";
        }

        // POST: api/Player
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Player/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Player/5
        public void Delete(int id)
        {
        }
    }
}
