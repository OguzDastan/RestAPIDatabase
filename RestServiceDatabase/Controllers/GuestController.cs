using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary_Hotel;
using RestServiceDatabase.DBUtil;

namespace RestServiceDatabase.Controllers
{
    public class GuestController : ApiController
    {
        ManageGuest mg = new ManageGuest();
        // GET: api/Guest
        public IEnumerable<Guest> Get()
        {
            return mg.GetAllGuest();
        }

        // GET: api/Guest/5
        public Guest Get(int id)
        {
            return mg.GetGuestFromId(id);
        }

        // POST: api/Guest
        public bool Post([FromBody]Guest value)
        {
            return mg.CreateGuest(value);
        }

        // PUT: api/Guest/5
        public bool Put(int id, [FromBody]Guest value)
        {
            return mg.UpdateGuest(value, id);
        }

        // DELETE: api/Guest/5
        public Guest Delete(int id)
        {

            return mg.DeleteGuest(id);
        }
    }
}
