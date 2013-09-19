using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MayiOA.Entities.Data;
using MayiOA.Entities.UserAgg;
using MayiOA.Web.Models;

namespace MayiOA.Web.Controllers
{
    public class UserController : ApiController
    {
        private MayiOAEntities db = new MayiOAEntities();

        private IUserRepository repository;

        public UserController()
        {
            repository = new UserRepository(db);
        }

        // GET api/User/5
        public Users GetUsers(int id)
        {
            Users user = repository.GetUserByUserID(id);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return user;
        }

        // GET api/User?clientid=&fullname=
        public IEnumerable<Users> GetUsers(int clientid, string fullName)
        {
            IEnumerable<Users> users = repository.SearchUsersByName(clientid, fullName);
            if (users == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return users;
        }

        // PUT api/User/5
        public HttpResponseMessage PutUsers(int id, Users user)
        {
            if (ModelState.IsValid && id == user.UserID)
            {
                try
                {
                    repository.SaveUser(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/User
        public HttpResponseMessage PostUsers(Users user)
        {
            if (ModelState.IsValid)
            {
                repository.SaveUser(user);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.UserID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/User/5
        public HttpResponseMessage DeleteUsers(int id)
        {

            Users user = repository.GetUserByUserID(id);
            try
            {
                repository.DeleteUser(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}